using Skidly.Domain.Exceptions.StudyArea;
using Skidly.Domain.ValueObjects.ApplicationUser;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Aggregates;

public sealed class ApplicationUser : AbstractIdentityUser
{
    private Fullname? _fullname;
    private DateOfBirth? _dateOfBirth;
    private Country? _country;
    private readonly List<StudyArea> _areas = new();

    private ApplicationUser()
    {
        // For Entity Framework
    }
    
    public ApplicationUser(string? fullname = null, string? dateOfBirth = null, string? country = null)
    {
        _fullname = fullname is null ? null : new Fullname(fullname);
        _dateOfBirth = dateOfBirth is null ? null : new DateOfBirth(dateOfBirth);
        _country = country is null ? null : new Country(country);
    }

    public Fullname? Fullname => _fullname;
    public DateOfBirth? DateOfBirth => _dateOfBirth;
    public Country? Country => _country;
    public IReadOnlyCollection<StudyArea> StudyAreas => _areas;
    
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
        if (_areas.Any(sa => sa.Name == area.Name))
        {
            throw new AreaWithSameNameAlreadyExistException();
        }
        
        _areas.Add(area);
    }
}