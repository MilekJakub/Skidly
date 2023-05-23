using Skidly.Domain.Constants;
using Skidly.Domain.Events;
using Skidly.Domain.Exceptions;
using Skidly.Domain.ValueObjects;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Entities;

public sealed class StudyGoal : Entity, IAggregateRoot
{
    private readonly List<Pomodoro> _pomodoros = new();

    private StudyGoal()
    {
        // For Entity Framework
    }
    
    public StudyGoal(
        GoalName name,
        GoalDescription description,
        GoalCategory category,
        GoalPriority priority,
        TimeSpan expectedLearningTime,
        Deadline deadline,
        bool isAchieved)
    {
        Name = name;
        Description = description;
        Category = category;
        Priority = priority;
        ExpectedLearningTime  ??= expectedLearningTime;
        Deadline ??= deadline;
        IsAchieved = isAchieved;
        
        AddEvent(new StudyGoalCreatedEvent(this));
    }
    
    public GoalName Name { get; private set; }
    public GoalDescription Description { get; private set; }
    public GoalCategory Category { get; private set; }
    public byte Priority { get; private set; }
    public TimeSpan? ExpectedLearningTime { get; private set; }
    public Deadline? Deadline { get; private set; }
    public bool IsAchieved { get; private set; }
    public IReadOnlyCollection<Pomodoro> Pomodoros => _pomodoros;
    
    public TimeSpan TimeSpentStudying
    {
        get
        {
            var total = new TimeSpan();
            foreach (var pomodoro in _pomodoros)
            {
                total = total.Add(pomodoro.Duration);
            }

            return total;
        }
    }

    internal void ChangeName(GoalName name)
    {
        Name = name;
        AddEvent(new GoalNameUpdatedEvent(this, Name));
    }
    
    internal void ChangeDescription(GoalDescription description)
    {
        Description = description;
        AddEvent(new GoalDescriptionUpdatedEvent(this, Description));
    }
    
    internal void ChangeCategory(GoalCategory category)
    {
        Category = category;
        AddEvent(new GoalCategoryUpdatedEvent(this, Category));
    }

    internal void ChangePriority(GoalPriority priority)
    {
        Priority = priority;
        AddEvent(new GoalPriorityUpdatedEvent(this, Priority));
    }

    internal void ChangeExpectedTimeToLearn(TimeSpan expectedTime)
    {
        ExpectedLearningTime = expectedTime;
        AddEvent(new GoalExpectedTimeToLearnUpdatedEvent(this, ExpectedLearningTime.Value));
    }

    internal void ChangeDeadline(Deadline deadline)
    {
        Deadline = deadline;
    }

    internal void MarkAsAchieved()
    {
        if (IsAchieved)
        {
            throw new GoalAlreadySetToAchievedException();
        }
        
        IsAchieved = true;
        AddEvent(new GoalMarkedAsAchievedEvent(this, IsAchieved));
    }

    internal void MarkAsNotAchieved()
    {
        if (!IsAchieved)
        {
            throw new GoalAlreadySetToNotAchievedException();
        }

        IsAchieved = false;
        AddEvent(new GoalMarkedAsNotAchievedEvent(this, IsAchieved));
    }

    internal void AddPomodoro(Pomodoro pomodoro)
    {
        _pomodoros.Add(pomodoro);
        AddEvent(new PomodoroAddedToGoalEvent(this, pomodoro));
    }

    internal void RemovePomodoro(Guid pomodoroId)
    {
        var pomodoro = GetPomodoro(pomodoroId);
        _pomodoros.Remove(pomodoro);
        AddEvent(new PomodoroRemovedFromGoalEvent(this, pomodoro));
    }

    private Pomodoro GetPomodoro(Guid pomodoroId)
    {
        var pomodoro = _pomodoros.FirstOrDefault(p => p.Id == pomodoroId);

        if (pomodoro is null)
        {
            throw new PomodoroNotFoundException();
        }

        return pomodoro;
    }
}