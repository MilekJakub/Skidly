using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class EmptyEmailAddressException : SkidlyException
{
    public EmptyEmailAddressException() : base("The email address cannot be empty.")
    {
    }
}