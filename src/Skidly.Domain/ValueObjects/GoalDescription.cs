using Skidly.Domain.Exceptions;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class GoalDescription : ValueObject
{
    public GoalDescription(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyGoalDescriptionException();

        if (name.Length > 250)
            throw new GoalDescriptionTooLongException();

        Value = name;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator string(GoalDescription description) => description.Value;
    public static implicit operator GoalDescription(string description) => new(description);

    public override string ToString()
    {
        return Value;
    }
}