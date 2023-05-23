using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Entities;

public class Role : Entity
{
    public Role(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("EmptyRoleNameException");
        }
        
        Name = name;
    }

    public string Name { get; private set; }
}