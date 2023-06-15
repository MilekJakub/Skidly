using Skidly.Domain.Aggregates;
using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Repositories;

public interface IStudyGoalRepository : IRepository<StudyGoal>
{
    Task AddAsync(StudyGoal goal, CancellationToken cancellationToken);
    Task<StudyGoal> GetAsync(Guid Id, CancellationToken cancellationToken);
}