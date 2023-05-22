using Skidly.Domain.Exceptions;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class GoalName : ValueObject
{
    public GoalName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyGoalNameException();

        if (name.Length > 25)
            throw new GoalNameTooLongException();

        Value = name;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator string(GoalName name) => name.Value;
    public static implicit operator GoalName(string name) => new(name);

    public override string ToString()
    {
        return Value;
    }
}