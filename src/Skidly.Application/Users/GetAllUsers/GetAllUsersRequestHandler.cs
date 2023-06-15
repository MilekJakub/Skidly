using Skidly.Application.DTOs;
using Skidly.Application.Services;
using Skidly.Application.Users.GetAllUsers;
using Skidly.Application.Users.GetUser;
using Skidly.Domain.Exceptions.ApplicationUser;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Infrastructure.EntityFramework.Queries;

public class GetAllUsersRequestHandler : IQueryHandler<GetAllUsersRequest, IEnumerable<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    { 
        var users = await _userRepository.GetAllUsers();

        if (!users.Any())
        {
            throw new Exception("There are no users in the database!");
        }

        var dtos = users
            .Select(u => new UserDto(
                u.UserName!,
                u.Email!,
                u.Fullname?.ToString(),
                u.DateOfBirth?.ToString(),
                u.Country?.ToString())
            )
            .ToList();

        return dtos;
    }
}