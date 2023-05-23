using Skidly.Domain.Events;
using Skidly.Domain.Exceptions;
using Skidly.Domain.ValueObjects;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Entities;

public sealed class StudyArea : Entity, IAggregateRoot
{
    private readonly List<StudyGoal> _goals = new();

    private StudyArea()
    {
        // For Entity Framework
    }

    public StudyArea(
        AreaName name,
        AreaDescription description)
    {
        Name = name;
        Description = description;
        
        AddEvent(new StudyAreaCreatedEvent(this));
    }
    
    public AreaName Name { get; private set; }
    public AreaDescription Description { get; private set; }
    public IReadOnlyCollection<StudyGoal> Goals => _goals;

    public TimeSpan TimeSpentStudying
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

    public void ChangeName(AreaName name)
    {
        Name = name;
        AddEvent(new AreaNameUpdatedEvent(this, Name));
    }

    public void ChangeDescription(AreaDescription description)
    {
        Description = description;
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