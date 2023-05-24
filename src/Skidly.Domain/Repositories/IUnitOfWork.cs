using System.Data;

namespace Skidly.Domain.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    IDbTransaction BeginTransaction();
}