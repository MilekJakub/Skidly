namespace Skidly.Infrastructure.EntityFramework.Models;

public class StudyAreaReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string TotalStudyingTime { get; set; }
    public ICollection<StudyGoalReadModel> StudyGoals { get; set; }
    public ApplicationUserReadModel ApplicationUser { get; set; }
}