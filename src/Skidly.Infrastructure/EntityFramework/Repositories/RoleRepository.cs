using Microsoft.EntityFrameworkCore;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework.Contexts;

namespace Skidly.Infrastructure.EntityFramework.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly DbSet<Role> _roles;

    public RoleRepository(WriteDbContext writeDbContext)
    {
        _roles = writeDbContext.Roles;
    }

    public async Task<Role> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await _roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        if (role is null)
        {
            throw new Exception("RoleNotFoundException");
        }

        return role;
    }
}