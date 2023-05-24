using Skidly.Domain.Aggregates;
using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Repositories;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    Task AddAsync(ApplicationUser user, CancellationToken cancellationToken);
    Task<ApplicationUser> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}