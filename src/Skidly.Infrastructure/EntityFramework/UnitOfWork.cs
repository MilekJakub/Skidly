using Skidly.Infrastructure.EntityFramework.Contexts;
using Skidly.Shared.Abstractions;

namespace Skidly.Infrastructure.EntityFramework;

public class UnitOfWork : IUnitOfWork
{
    private readonly WriteDbContext _writeDbContext;

    public UnitOfWork(WriteDbContext writeDbContext)
    {
        _writeDbContext = writeDbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _writeDbContext.SaveChangesAsync(cancellationToken);
    }
}