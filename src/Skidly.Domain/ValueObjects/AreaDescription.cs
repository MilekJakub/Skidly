using Skidly.Domain.Exceptions;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class AreaDescription : ValueObject
{
    public AreaDescription(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyAreaDescriptionException();

        if (name.Length > 250)
            throw new AreaDescriptionTooLongException();

        Value = name;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator string(AreaDescription description) => description.Value;
    public static implicit operator AreaDescription(string description) => new(description);

    public override string ToString()
    {
        return Value;
    }
}