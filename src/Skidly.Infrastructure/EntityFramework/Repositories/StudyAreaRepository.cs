using Microsoft.EntityFrameworkCore;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Exceptions.StudyArea;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework.Contexts;

namespace Skidly.Infrastructure.EntityFramework.Repositories;

public class StudyAreaRepository : IStudyAreaRepository
{
    private readonly DbSet<StudyArea> _areas;

    public StudyAreaRepository(ApplicationDbContext applicationDbContext)
    {
        _areas = applicationDbContext.StudyAreas;
    }
    
    public async Task AddAsync(StudyArea area, CancellationToken cancellationToken)
        => await _areas.AddAsync(area, cancellationToken);

    public async Task<StudyArea> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var area = await _areas
            .Include(a => a.Goals)
            .ThenInclude(g => g.Pomodoros)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken: cancellationToken);

        if (area is null)
        {
            throw new StudyAreaNotFoundException(id.ToString());
        }

        return area;
    }
}