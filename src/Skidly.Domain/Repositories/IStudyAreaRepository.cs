using Skidly.Domain.Aggregates;
using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Repositories;

public interface IStudyAreaRepository : IRepository<StudyArea>
{
    Task AddAsync(StudyArea area, CancellationToken cancellationToken);
    Task<StudyArea> GetAsync(Guid id, CancellationToken cancellationToken);
}
