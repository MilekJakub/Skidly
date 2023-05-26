namespace Skidly.Infrastructure.EntityFramework.Models;

public class PomodoroReadModel
{
    public Guid Id { get; set; }
    public string Topic { get; private set; }
    public string ExpectedDuration { get; private set; }
    public string Duration { get; private set; }
    public DateTime? StartTime { get; private set; }
    public DateTime? FinishTime { get; private set; }
    public bool IsFinished { get; private set; }
    public StudyGoalReadModel StudyGoal { get; set; }
}