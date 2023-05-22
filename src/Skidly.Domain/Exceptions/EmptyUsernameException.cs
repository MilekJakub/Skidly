using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class EmptyUsernameException : SkidlyException
{
    public EmptyUsernameException() : base("The username cannot be empty.")
    {
    }
}