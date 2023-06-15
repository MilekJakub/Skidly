using Skidly.Domain.Exceptions.StudyArea;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.StudyArea;

public class StudyAreaName : ValueObject
{
    private StudyAreaName()
    {
        // For Entity Framework
    }
    
    public StudyAreaName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyAreaNameException();

        if (name.Length > 25)
            throw new AreaNameTooLongException();

        Value = name;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator string(StudyAreaName name) => name.Value;
    public static implicit operator StudyAreaName(string name) => new(name);

    public override string ToString()
    {
        return Value;
    }
}