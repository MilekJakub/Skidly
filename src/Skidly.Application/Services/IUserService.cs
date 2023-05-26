using Skidly.Application.DTOs;

namespace Skidly.Application.Services;

public interface IUserService
{
    Task<List<UserDto>> GetEmployees();
    Task<UserDto> GetEmployee(string userId);
}