using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Repositories;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task AddAsync(ApplicationUser user);
    Task<ApplicationUser> GetAsync(Guid id);
}