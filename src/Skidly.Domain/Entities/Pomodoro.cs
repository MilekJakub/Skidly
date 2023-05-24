using Skidly.Domain.Aggregates;
using Skidly.Domain.Events.Pomodoro;
using Skidly.Domain.ValueObjects;
using Skidly.Domain.ValueObjects.Pomodoro;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Entities;

public sealed class Pomodoro : Entity
{
    private Pomodoro()
    {
        // For Entity Framework
    }
    
    public Pomodoro(PomodoroTopic topic, TimeSpan expectedDuration)
    {
        Topic = topic;
        ExpectedDuration = expectedDuration;
        
        AddEvent(new PomodoroCreatedEvent(this));
    }

    public PomodoroTopic Topic { get; private set; }
    public TimeSpan ExpectedDuration { get; private set; }
    public TimeSpan Duration { get; private set; }
    public DateTime? StartTime { get; private set; }
    public DateTime? FinishTime { get; private set; }
    public bool IsFinished { get; private set; }
    public StudyGoal Goal { get; set; }

    public void ChangeTopic(PomodoroTopic topic)
    {
        Topic = topic;
        AddEvent(new PomodoroTopicUpdatedEvent(this, Topic));
    }

    public void ChangeExpectedDuration(TimeSpan expectedDuration)
    {
        ExpectedDuration = expectedDuration;
        AddEvent(new PomodoroExpectedDurationUpdatedEvent(this, ExpectedDuration));
    }

    public void AddTimeToDuration(TimeSpan duration)
    {
        Duration = Duration.Add(duration);
        AddEvent(new PomodoroDurationIncreasedEvent(this, Duration));
    }

    public void SetStartTime(DateTime startTime)
    {
        StartTime = startTime;
        AddEvent(new PomodoroStartTimeSetEvent(this, StartTime.Value));
    }

    public void SetEndTime(DateTime endTime)
    {
        FinishTime = endTime;
        IsFinished = true;
        AddEvent(new PomodoroEndTimeSetEvent(this, FinishTime.Value));
    }
}