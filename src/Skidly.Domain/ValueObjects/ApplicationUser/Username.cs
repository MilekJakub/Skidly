using Skidly.Domain.Exceptions.ApplicationUser;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.ApplicationUser;

public class Username : ValueObject
{
    private Username()
    {
        // For Entity Framework
    }
    
    public Username(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new EmptyUsernameException();

        if (name.Length > 25)
            throw new UsernameTooLongException();

        Value = name;
    }
    
    public string Value { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    
    public static implicit operator string(Username username) => username.Value;
    public static implicit operator Username(string username) => new(username);

    public override string ToString()
    {
        return Value;
    }
}