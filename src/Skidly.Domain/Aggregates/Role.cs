using Skidly.Domain.ValueObjects.Role;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Aggregates;

public class Role : Entity, IAggregateRoot
{
    private readonly List<ApplicationUser> _users = new();

    private Role()
    {
        // For Entity Framework
    }
    
    public Role(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("EmptyRoleNameException");
        }
        
        Name = new RoleName(name);
    }

    public RoleName Name { get; private set; }
    public IReadOnlyCollection<ApplicationUser> Users => _users;

    public void AddUser(ApplicationUser user)
    {
        _users.Add(user);
    }

    public override string ToString()
    {
        return Name.ToString();
    }
}