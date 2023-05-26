using Skidly.Application.DTOs;
using Skidly.Application.Services;

namespace Skidly.Infrastructure.Identity.Services;

public class UserService : IUserService
{
    public Task<List<UserDto>> GetEmployees()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetEmployee(string userId)
    {
        throw new NotImplementedException();
    }
}