using Skidly.Domain.Exceptions.StudyArea;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.StudyArea;

public class StudyAreaDescription : ValueObject
{
    private StudyAreaDescription()
    {
        // For Entity Framework
    }
    
    public StudyAreaDescription(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyAreaDescriptionException();

        if (name.Length > 500)
            throw new AreaDescriptionTooLongException();

        Value = name;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator string(StudyAreaDescription description) => description.Value;
    public static implicit operator StudyAreaDescription(string description) => new(description);

    public override string ToString()
    {
        return Value;
    }
}