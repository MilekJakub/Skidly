using Skidly.Domain.Exceptions;
using Skidly.Domain.ValueObjects;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Entities;

public sealed class ApplicationUser : Entity, IAggregateRoot
{
    private readonly List<StudyArea> _studyAreas = new();

    private ApplicationUser()
    {
        // For Entity Framework
    }
    
    public ApplicationUser(
        Username username,
        EmailAddress email,
        Fullname? fullname,
        DateOfBirth? dateOfBirth,
        Country? country)
    {
        Username = username;
        Email = email;
        Fullname ??= fullname;
        DateOfBirth ??= dateOfBirth;
        Country ??= country;
    }

    public Username Username { get; private set; }
    public EmailAddress Email { get; private set; }
    public Fullname? Fullname { get; private set; }
    public DateOfBirth? DateOfBirth { get; private set; }
    public Country? Country { get; private set; }
    public PasswordHash PasswordHash { get; set; }
    public Role Role { get; private set; }
    
    public IReadOnlyCollection<StudyArea> StudyAreas => _studyAreas;
    
    public TimeSpan TotalStudyTime
    {
        get
        {
            var total = new TimeSpan();

            foreach (var studyArea in StudyAreas)
            {
                total = total.Add(studyArea.TimeSpentStudying);
            }

            return total;
        }
    }

    public void SetPasswordHash(string hash)
    {
        PasswordHash = new PasswordHash(hash);
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