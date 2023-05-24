using MediatR;
using Microsoft.AspNetCore.Identity;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Repositories;

namespace Skidly.Application.Users.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUser>
{
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserHandler(
        IPasswordHasher<ApplicationUser> passwordHasher,
        IApplicationUserRepository applicationUserRepository,
        IUnitOfWork unitOfWork,
        IRoleRepository roleRepository)
    {
        _passwordHasher = passwordHasher;
        _applicationUserRepository = applicationUserRepository;
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    public async Task Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser(
            request.Username,
            request.EmailAddress,
            request.Fullname,
            request.DateOfBirth,
            request.Country);
        
        var hash = _passwordHasher.HashPassword(user, request.Password);
        var role = await _roleRepository.GetByIdAsync(request.RoleId, cancellationToken);
        
        user.SetPasswordHash(hash);
        user.AddRole(role);

        await _applicationUserRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        request.Id = user.Id;
    }
}