using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework.Contexts;

namespace Skidly.Infrastructure.EntityFramework.Repositories;

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

    public IDbTransaction BeginTransaction()
    {
        var transaction = _writeDbContext.Database.BeginTransaction();

        return transaction.GetDbTransaction();
    }
}