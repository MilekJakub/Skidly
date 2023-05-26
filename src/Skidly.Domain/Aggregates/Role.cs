using System.ComponentModel.DataAnnotations.Schema;
using Skidly.Domain.ValueObjects.Role;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Aggregates;

[NotMapped]
public class Role : AbstractIdentityRole
{
    public Role()
    {
    }
}