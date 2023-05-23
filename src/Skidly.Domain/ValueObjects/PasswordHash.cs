using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class PasswordHash : ValueObject
{
    public PasswordHash(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exception("EmptyPasswordHashException()");
        }
        
        Value = value;
    }

    public string Value { get; set; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}