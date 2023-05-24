using Skidly.Domain.Aggregates;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}