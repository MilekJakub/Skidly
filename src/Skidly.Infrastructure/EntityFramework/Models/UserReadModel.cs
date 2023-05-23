namespace Skidly.Infrastructure.EntityFramework.Models;

public sealed class UserReadModel
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Fullname { get; set; }
    public string DateOfBirth { get; set; }
    public string Country { get; set; }
    public ICollection<StudyAreaReadModel> Areas { get; set; }
}