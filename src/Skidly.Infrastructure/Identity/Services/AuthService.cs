using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Skidly.Application.Services;
using Skidly.Application.Users.LoginUser;
using Skidly.Application.Users.RegisterUser;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Exceptions.ApplicationUser;

namespace Skidly.Infrastructure.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<LoginUserResponse> Login(LoginUserRequest request, CancellationToken cancellationToken = default)
    {
        var authSettings = new AuthSettings();
        _configuration.GetSection("Authorization").Bind(authSettings);
        
        var user = await _userManager.FindByNameAsync(request.Username);

        if (user is null)
        {
            throw new UserWithUsernameNotFoundException(request.Username);
        }

        var signInResult = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

        if (!signInResult.Succeeded)
        {
            throw new InvalidCredentialsException();
        }

        var jwtSecurityToken = await GenerateToken(user, authSettings);

        var response = new LoginUserResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName
        };

        return response;
    }

    public async Task<RegisterUserResponse> Register(RegisterUserRequest request, CancellationToken cancellationToken = default)
    {
        var existingUser = await _userManager.FindByNameAsync(request.UserName);

        if (existingUser is not null)
        {
            throw new UsernameAlreadyExistsException(request.UserName);
        }
        
        var existingEmail = await _userManager.FindByEmailAsync(request.Email);
        
        if (existingEmail is not null)
        {
            throw new EmailAlreadyExistsException(request.Email);
        }

        var user = new ApplicationUser(request.Fullname, request.DateOfBirth, request.Country)
        {
            UserName = request.UserName,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception($"{result.Errors}");
        }
        
        await _userManager.AddToRoleAsync(user, "User");
        
        return new RegisterUserResponse() { UserId = user.Id };
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user, AuthSettings authSettings)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: authSettings.Issuer,
            audience: authSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(authSettings.DurationInMinutes),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}