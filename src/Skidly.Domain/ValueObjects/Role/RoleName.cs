using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.ValueObjects.Role;

public class RoleName : ValueObject
{
    public RoleName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("EmptyRoleNameException()");
        }

        if (name.Length > 25)
        {
            throw new Exception("RoleNameTooLongException()");
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