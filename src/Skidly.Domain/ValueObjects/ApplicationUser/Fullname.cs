using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.ApplicationUser;

public class Fullname : ValueObject
{
    private Fullname()
    {
        // For Entity Framework
    }

    public Fullname(string fullname)
    {
        if (fullname.Length > 100)
        {
            throw new Exception("FullnameTooLongException");
        }

        Value = fullname;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}