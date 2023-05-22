using Skidly.Domain.Exceptions;
using Skidly.Domain.ValueObjects;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Entities;

public sealed class User : Entity, IAggregateRoot
{
    private readonly List<StudyArea> _studyAreas = new();
    
    public User(Username username, EmailAddress email, IEnumerable<StudyArea> studyAreas)
    {
        Username = username;
        Email = email;
    }

    public Username Username { get; private set; }
    public EmailAddress Email { get; private set; }
    public IReadOnlyCollection<StudyArea> StudyAreas => _studyAreas;
    
    public TimeSpan TotalStudyTime
    {
        get
        {
            var total = new TimeSpan();

            foreach (var studyArea in StudyAreas)
            {
                total = total.Add(studyArea.TotalStudyingTime);
            }

            return total;
        }
    }

    public void AddStudyArea(StudyArea area)
    {
        if (_studyAreas.Any(sa => sa.Name == area.Name))
        {
            throw new AreaWithSameNameAlreadyExistException();
        }
        
        _studyAreas.Add(area);
    }
}