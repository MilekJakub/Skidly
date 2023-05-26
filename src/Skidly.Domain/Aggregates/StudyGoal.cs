using Skidly.Domain.Constants;
using Skidly.Domain.Entities;
using Skidly.Domain.Events.StudyGoal;
using Skidly.Domain.Exceptions.Pomodoro;
using Skidly.Domain.Exceptions.StudyGoal;
using Skidly.Domain.ValueObjects.StudyGoal;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Aggregates;

public class StudyGoal : AbstractEntity, IAggregateRoot
{
    
    private StudyGoalName _name;
    private StudyGoalDescription _description;
    private StudyGoalCategory _category;
    private byte _priority;
    private TimeSpan? _expectedLearningTime;
    private Deadline? _deadline;
    private bool _isAchieved;
    
    private StudyArea _area;
    private Guid _areaId;
    private readonly List<Pomodoro> _pomodoros = new();

    private StudyGoal()
    {
        // For Entity Framework
    }
    
    public StudyGoal(
        Guid id,
        string name,
        string description,
        string category,
        byte priority,
        TimeSpan? expectedLearningTime,
        DateTime? deadline,
        bool isAchieved,
        StudyArea area,
        Guid areaId)
    {
        Id = id;
        _name = new StudyGoalName(name);
        _description = new StudyGoalDescription(description);
        _category =  (StudyGoalCategory) Enum.Parse(typeof(StudyGoalCategory), category);
        _priority = new GoalPriority(priority);
        _expectedLearningTime  = expectedLearningTime;
        _deadline = deadline is null ? null : new Deadline(deadline.Value);
        _isAchieved = isAchieved;
        _area = area;
        _areaId = areaId;
        
        AddEvent(new StudyGoalCreatedEvent(this));
    }

    public StudyGoalName Name => _name;
    public StudyGoalDescription Description => _description;
    public StudyGoalCategory Category => _category;
    public byte Priority => _priority;
    public TimeSpan? ExpectedLearningTime => _expectedLearningTime;
    public Deadline? Deadline => _deadline;
    public bool IsAchieved => _isAchieved;

    public virtual IReadOnlyCollection<Pomodoro> Pomodoros => _pomodoros;
    
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

    public Guid GetAreaId()
    {
        return _areaId;
    }

    internal void ChangeName(StudyGoalName name)
    {
        _name = name;
        AddEvent(new GoalNameUpdatedEvent(this, Name));
    }
    
    internal void ChangeDescription(StudyGoalDescription description)
    {
        _description = description;
        AddEvent(new GoalDescriptionUpdatedEvent(this, Description));
    }
    
    internal void ChangeCategory(StudyGoalCategory category)
    {
        _category = category;
        AddEvent(new GoalCategoryUpdatedEvent(this, Category));
    }

    internal void ChangePriority(GoalPriority priority)
    {
        _priority = priority;
        AddEvent(new GoalPriorityUpdatedEvent(this, Priority));
    }

    internal void ChangeExpectedTimeToLearn(TimeSpan expectedTime)
    {
        _expectedLearningTime = expectedTime;
        AddEvent(new GoalExpectedTimeToLearnUpdatedEvent(this, ExpectedLearningTime.Value));
    }

    internal void ChangeDeadline(Deadline deadline)
    {
        _deadline = deadline;
    }

    internal void MarkAsAchieved()
    {
        if (IsAchieved)
        {
            throw new GoalAlreadySetToAchievedException();
        }
        
        _isAchieved = true;
        AddEvent(new GoalMarkedAsAchievedEvent(this, IsAchieved));
    }

    internal void MarkAsNotAchieved()
    {
        if (!IsAchieved)
        {
            throw new GoalAlreadySetToNotAchievedException();
        }

        _isAchieved = false;
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