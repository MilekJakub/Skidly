using System.Collections;

namespace Skidly.Infrastructure.EntityFramework.Models;

public class StudyGoalReadModel
{
    // name desc category priority expectedLearningTime deadline isAchieved
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Priority { get; set; }
    public string? ExpectedLearningTime { get; set; }
    public string? Deadline { get; set; }
    public string IsAchieved { get; set; }
    public ICollection<PomodoroReadModel> Pomodoros { get; set; }
    public StudyAreaReadModel StudyArea { get; set; }
}