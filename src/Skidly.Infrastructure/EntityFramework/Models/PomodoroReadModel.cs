namespace Skidly.Infrastructure.EntityFramework.Models;

public class PomodoroReadModel
{
    // topic expectedDuration duration startTime finishTime isFinished
    public string Id { get; set; }
    public string Topic { get; private set; }
    public string ExpectedDuration { get; private set; }
    public string Duration { get; private set; }
    public string? StartTime { get; private set; }
    public string? FinishTime { get; private set; }
    public string IsFinished { get; private set; }
    public StudyGoalReadModel StudyGoal { get; set; }
}