using MediatR;
using Microsoft.AspNetCore.Identity;
using Skidly.Domain.Entities;
using Skidly.Domain.Repositories;
using Skidly.Shared.Abstractions;

namespace Skidly.Application.Users.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUser>
{
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IPasswordHasher<ApplicationUser> passwordHasher, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser(
            request.Username,
            request.EmailAddress,
            request.Fullname,
            request.DateOfBirth,
            request.Country);
        
        var hash = _passwordHasher.HashPassword(user, request.Password);
        user.SetPasswordHash(hash);

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}