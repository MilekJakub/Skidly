using Microsoft.EntityFrameworkCore;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Entities;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework.Contexts;
using Skidly.Shared.Abstractions;

namespace Skidly.Infrastructure.EntityFramework.Repositories;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly DbSet<ApplicationUser> _users;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationUserRepository(WriteDbContext writeDbContext, IUnitOfWork unitOfWork)
    {
        _users = writeDbContext.Users;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        await _users.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ApplicationUser> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null)
        {
            throw new Exception("UserNotFoundException");
        }
        
        return user;
    }
}