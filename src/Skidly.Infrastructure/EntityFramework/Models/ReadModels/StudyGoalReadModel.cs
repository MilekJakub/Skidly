using Skidly.Domain.Constants;

namespace Skidly.Infrastructure.EntityFramework.Models;

public class StudyGoalReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public StudyGoalCategory Category { get; set; }
    public byte Priority { get; set; }
    public string? ExpectedLearningTime { get; set; }
    public int TotalStudyingTime { get; set; }
    public DateTime? Deadline { get; set; }
    public bool IsAchieved { get; set; }
    public StudyAreaReadModel StudyArea { get; set; }
    public ICollection<PomodoroReadModel> Pomodoros { get; set; }
}