using Skidly.Domain.Aggregates;
using Skidly.Domain.Entities;

namespace Skidly.Application.DTOs;

public static class WriteModelMapper
{
    public static UserDto UserDto(ApplicationUser user)
    {
        return new UserDto(
            user.Username.Value,
            user.Email.Value,
            user?.Fullname?.ToString(),
            user?.DateOfBirth?.ToString(),
            user?.Country?.Name);
    }
    
}