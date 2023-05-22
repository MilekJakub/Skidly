using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class UsernameTooLongException : SkidlyException
{
    public UsernameTooLongException() : base("The username is too long (max 25 characters)")
    {
    }
}