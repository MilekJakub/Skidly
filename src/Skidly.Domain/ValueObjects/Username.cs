using Skidly.Domain.Exceptions;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects;

public class Username : ValueObject
{
    
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