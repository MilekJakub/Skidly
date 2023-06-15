using Skidly.Application.DTOs;
using Skidly.Application.Services;
using Skidly.Application.Users.GetUser;
using Skidly.Domain.Exceptions.ApplicationUser;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Infrastructure.EntityFramework.Queries;

public class GetUserRequestHandler : IQueryHandler<GetUserRequest, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.Id.ToString());

        if (user is null)
        {
            throw new UserNotFoundException(request.Id.ToString());
        }

        return DtoMapper.UserDto(user);
    }
}