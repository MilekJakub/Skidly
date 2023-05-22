using Skidly.Domain.Exceptions;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class AreaName : ValueObject
{
    public AreaName(string name)
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
    
    public static implicit operator string(AreaName name) => name.Value;
    public static implicit operator AreaName(string name) => new(name);

    public override string ToString()
    {
        return Value;
    }
}