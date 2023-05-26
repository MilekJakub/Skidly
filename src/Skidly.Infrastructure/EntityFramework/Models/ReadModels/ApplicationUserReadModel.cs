using Microsoft.EntityFrameworkCore.Storage;

namespace Skidly.Infrastructure.EntityFramework.Models;

public sealed class ApplicationUserReadModel
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Fullname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Country { get; set; }
    public RoleReadModel Role { get; set; }
    public ICollection<StudyAreaReadModel> StudyAreas { get; set; }
}