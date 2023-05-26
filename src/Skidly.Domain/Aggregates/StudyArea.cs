using Skidly.Domain.Events.StudyArea;
using Skidly.Domain.Exceptions.StudyGoal;
using Skidly.Domain.ValueObjects.StudyArea;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Aggregates;

public sealed class StudyArea : AbstractEntity, IAggregateRoot
{
    private readonly List<StudyGoal> _goals = new();
    private StudyAreaName _name;
    private StudyAreaDescription _description;
    private ApplicationUser _user;

    private StudyArea()
    {
        // For Entity Framework
    }

    public StudyArea(
        StudyAreaName name,
        StudyAreaDescription description,
        ApplicationUser user)
    {
        _name = name;
        _description = description;
        
        AddEvent(new StudyAreaCreatedEvent(this));
    }

    public StudyAreaName Name => _name;
    public StudyAreaDescription Description => _description;
    public ApplicationUser User => _user;
    public IReadOnlyCollection<StudyGoal> Goals => _goals;

    public TimeSpan TotalStudyingTime
    {
        get
        {
            var total = new TimeSpan();
            
            foreach (var goal in _goals)
            {
                total = total.Add(goal.TimeSpentStudying);
            }

            return total;
        }
    }
    
    public void AddGoal(StudyGoal goal)
    {
        var alreadyExists = _goals.Any(sg => sg.Name == goal.Name);

        if (alreadyExists)
            throw new GoalWithSameNameAlreadyExistException(goal.Name);
        
        _goals.Add(goal);
        
        AddEvent(new GoalAddedEvent(this, goal));
    }

    public void RemoveGoal(Guid goalId)
    {
        var goal = GetGoal(goalId);
        
        _goals.Remove(goal);
        
        AddEvent(new GoalRemovedEvent(this, goal));
    }

    public void ChangeName(StudyAreaName name)
    {
        _name = name;
        AddEvent(new AreaNameUpdatedEvent(this, Name));
    }

    public void ChangeDescription(StudyAreaDescription description)
    {
        _description = description;
        AddEvent(new AreaDescriptionUpdatedEvent(this, Description));
    }

    private StudyGoal GetGoal(Guid goalId)
    {
        var goal = _goals.SingleOrDefault(sg => sg.Id == goalId);

        if (goal is null)
        {
            throw new GoalNotFoundException();
        }
        
        return goal;
    }
}