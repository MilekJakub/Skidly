using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.Role;

public class RoleNameTooLongException : ValidationException, ISkidlyException
{
    public RoleNameTooLongException(string name) : base($"The role name '{name}' is too long. Max role name length is 25.")
    {
    }
}