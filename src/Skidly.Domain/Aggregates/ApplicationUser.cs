using Skidly.Domain.Exceptions.StudyArea;
using Skidly.Domain.ValueObjects.ApplicationUser;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Aggregates;

public sealed class ApplicationUser : Entity, IAggregateRoot
{
    private readonly List<StudyArea> _studyAreas = new();

    private ApplicationUser()
    {
        // For Entity Framework
    }
    
    public ApplicationUser(
        string username,
        string email,
        string? fullname,
        string? dateOfBirth,
        string? country)
    {
        var validUsername = new Username(username);
        var validEmail = new EmailAddress(email);
        var validFullname = fullname != null ? new Fullname(fullname) : null;
        var validDateOfBirth = dateOfBirth != null ? new DateOfBirth(dateOfBirth) : null;
        var validCountry = country != null ? new Country(country) : null;
        
        Username = validUsername;
        Email = validEmail;
        Fullname ??= validFullname;
        DateOfBirth ??= validDateOfBirth;
        Country ??= validCountry;
    }

    public Username Username { get; private set; }
    public EmailAddress Email { get; private set; }
    public Fullname? Fullname { get; private set; }
    public DateOfBirth? DateOfBirth { get; private set; }
    public Country? Country { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
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

        private set
        {
            
        }
    }

    public void SetPasswordHash(string hash)
    {
        PasswordHash = new PasswordHash(hash);
    }

    public void AddRole(Role role)
    {
        Role = role;
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