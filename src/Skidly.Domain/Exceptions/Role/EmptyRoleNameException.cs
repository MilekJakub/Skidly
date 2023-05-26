using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.Role;

public class EmptyRoleNameException : ValidationException, ISkidlyException
{
    public EmptyRoleNameException() : base("The role name cannot be empty.")
    {
    }
}