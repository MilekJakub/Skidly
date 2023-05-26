using Skidly.Domain.Aggregates;
using Skidly.Domain.Events.Pomodoro;
using Skidly.Domain.ValueObjects;
using Skidly.Domain.ValueObjects.Pomodoro;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Entities;

public sealed class Pomodoro : AbstractEntity
{
    
    private PomodoroTopic _topic;
    private TimeSpan _expectedDuration;
    private TimeSpan _duration;
    private DateTime? _startTime;
    private DateTime? _finishTime;
    private bool _isFinished;
    private readonly StudyGoal _goal;
    
    private Pomodoro()
    {
        // For Entity Framework
    }
    
    public Pomodoro(
        PomodoroTopic topic,
        TimeSpan expectedDuration,
        TimeSpan duration,
        DateTime? startTime,
        DateTime? finishTime,
        bool isFinished,
        StudyGoal goal)
    {
        _topic = topic;
        _expectedDuration = expectedDuration;
        _duration = duration;
        _startTime = startTime;
        _finishTime = finishTime;
        _isFinished = isFinished;
        _goal = goal;

        AddEvent(new PomodoroCreatedEvent(this));
    }

    public PomodoroTopic Topic => _topic;
    public TimeSpan ExpectedDuration => _expectedDuration;
    public TimeSpan Duration => _duration;
    public DateTime? StartTime => _startTime;
    public DateTime? FinishTime => _finishTime;
    public bool IsFinished => _isFinished;
    public StudyGoal Goal => _goal;

    public void ChangeTopic(PomodoroTopic topic)
    {
        _topic = topic;
        AddEvent(new PomodoroTopicUpdatedEvent(this, _topic));
    }

    public void ChangeExpectedDuration(TimeSpan expectedDuration)
    {
        _expectedDuration = expectedDuration;
        AddEvent(new PomodoroExpectedDurationUpdatedEvent(this, _expectedDuration));
    }

    public void AddTimeToDuration(TimeSpan duration)
    {
        _duration = _duration.Add(duration);
        AddEvent(new PomodoroDurationIncreasedEvent(this, _duration));
    }

    public void SetStartTime(DateTime startTime)
    {
        _startTime = startTime;
        AddEvent(new PomodoroStartTimeSetEvent(this, _startTime.Value));
    }

    public void SetEndTime(DateTime endTime)
    {
        _finishTime = endTime;
        _isFinished = true;
        AddEvent(new PomodoroEndTimeSetEvent(this, _finishTime.Value));
    }
}