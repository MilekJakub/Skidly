using Microsoft.AspNetCore.Identity;
using Skidly.Application.Services;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Exceptions.ApplicationUser;

namespace Skidly.Infrastructure.Identity.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<ApplicationUser>> GetAllUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("User");

        return users.ToList();
    }

    public async Task<ApplicationUser> GetUserById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        return user;
    }
}