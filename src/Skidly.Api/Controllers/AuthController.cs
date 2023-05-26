using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skidly.Application.Services;
using Skidly.Application.Users.GetUser;
using Skidly.Application.Users.LoginUser;
using Skidly.Application.Users.RegisterUser;
using Skidly.Shared.Abstractions.API;

namespace Skidly.Api.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ApiController
{
    private readonly IAuthService _authService;
    
    public AuthController(ISender sender, IAuthService authService) : base(sender)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IResult> RegisterUser([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.Register(request, cancellationToken);
        return Results.Created($"/api/users/{response.UserId}", null);
    }

    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        return Results.Ok(await _authService.Login(request, cancellationToken));
    }
}