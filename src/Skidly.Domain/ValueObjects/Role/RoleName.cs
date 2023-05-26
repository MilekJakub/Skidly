using Skidly.Domain.Exceptions.Role;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.Role;

public class RoleName : ValueObject
{
    private RoleName()
    {
        // For Entity Framework
    }
    
    public RoleName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyRoleNameException();
        }

        if (name.Length > 25)
        {
            throw new RoleNameTooLongException(name);
        }

        Name = name;
    }

    public string Name { get; private set; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
    }

    public override string ToString()
    {
        return Name;
    }
}