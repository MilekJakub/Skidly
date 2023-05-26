using Skidly.Application.DTOs;

namespace Skidly.Infrastructure.EntityFramework.Models;

public static class ReadModelMapper
{
    public static UserDto UserDto(ApplicationUserReadModel user)
    {
        return new UserDto(
            user.UserName,
            user.Email,
            user.Fullname,
            user.DateOfBirth.ToString(),
            user.Country);
    }
}