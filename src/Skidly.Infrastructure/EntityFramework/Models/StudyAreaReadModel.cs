namespace Skidly.Infrastructure.EntityFramework.Models;

public class StudyAreaReadModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string TotalStudyingTime { get; set; }
    public ICollection<StudyGoalReadModel> Goals { get; set; }
    public UserReadModel User { get; set; }
}