using Skidly.Domain.Exceptions.StudyGoal;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.StudyGoal;

public class GoalPriority : ValueObject
{
    private GoalPriority()
    {
        // For Entity Framework
    }
    
    public GoalPriority(byte value)
    {
        if (value < 1 || value > 10)
        {
            throw new InvalidPriorityException();
        }
        
        Value = value;
    }

    public byte Value { get; private set; }


    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator byte(GoalPriority priority) => priority.Value;
    public static implicit operator GoalPriority(byte priority) => new(priority);
    
    public override string ToString()
    {
        return Value.ToString();
    }
}