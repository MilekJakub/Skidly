using Microsoft.EntityFrameworkCore;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Exceptions.StudyArea;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework.Contexts;

namespace Skidly.Infrastructure.EntityFramework.Repositories;
public class StudyGoalRepository : IStudyGoalRepository
{
    private readonly DbSet<StudyGoal> _areas;

    public StudyGoalRepository(ApplicationDbContext applicationDbContext)
    {
        _areas = applicationDbContext.StudyGoals;
    }
    
    public async Task AddAsync(StudyGoal goal, CancellationToken cancellationToken)
        => await _areas.AddAsync(goal, cancellationToken);

    public async Task<StudyGoal> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var goal = await _areas
            .Include(sg => sg.Pomodoros)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken: cancellationToken);

        if (goal is null)
        {
            throw new StudyAreaNotFoundException(id.ToString());
        }

        return goal;
    }
}
