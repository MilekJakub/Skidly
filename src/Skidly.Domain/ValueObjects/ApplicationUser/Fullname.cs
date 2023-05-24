using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.ApplicationUser;

public class Fullname : ValueObject
{
    
    public Fullname(string fullname)
    {
        if (fullname.Length > 100)
        {
            throw new Exception("FullnameTooLongException");
        }
        
        var split = fullname.Split(' ');
        Value = split;
    }
    
    public string[] Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return string.Join(' ', Value);
    }
}