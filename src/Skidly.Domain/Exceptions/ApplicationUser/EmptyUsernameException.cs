using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public sealed class EmptyUsernameException : ValidationException, ISkidlyException
{
    public EmptyUsernameException() : base("The username cannot be empty.")
    {
    }
}