using Skidly.Domain.Exceptions.StudyGoal;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.StudyGoal;

public class StudyGoalName : ValueObject
{
    private StudyGoalName()
    {
        // For Entity Framework
    }
    
    public StudyGoalName(string name)
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
    
    public static implicit operator string(StudyGoalName name) => name.Value;
    public static implicit operator StudyGoalName(string name) => new(name);

    public override string ToString()
    {
        return Value;
    }
}