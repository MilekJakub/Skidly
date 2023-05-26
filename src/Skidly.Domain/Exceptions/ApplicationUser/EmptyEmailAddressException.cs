using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public sealed class EmptyEmailAddressException : ValidationException, ISkidlyException
{
    public EmptyEmailAddressException() : base("The email address cannot be empty.")
    {
    }
}