using Skidly.Application.DTOs;
using Skidly.Application.Users.GetUser;
using Skidly.Domain.Entities;
using Skidly.Domain.Repositories;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Infrastructure.EntityFramework.Queries;

public class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUser request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id);
        var userDto = Mapper.ToUserDto(user);
        return userDto;
    }
}