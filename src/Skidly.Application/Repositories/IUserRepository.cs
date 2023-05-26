using Skidly.Domain.Aggregates;

namespace Skidly.Application.Services;

public interface IUserRepository
{
    Task<List<ApplicationUser>> GetAllUsers();
    Task<ApplicationUser> GetUserById(string userId);
}