using Skidly.Domain.Exceptions.StudyGoal;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.StudyGoal;

public class StudyGoalDescription : ValueObject
{
    private StudyGoalDescription()
    {
        // For Entity Framework
    }

    public StudyGoalDescription(string name)
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
    
    public static implicit operator string(StudyGoalDescription description) => description.Value;
    public static implicit operator StudyGoalDescription(string description) => new(description);

    public override string ToString()
    {
        return Value;
    }
}