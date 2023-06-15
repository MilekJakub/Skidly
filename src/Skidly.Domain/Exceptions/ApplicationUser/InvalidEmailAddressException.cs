using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public sealed class InvalidEmailAddressException : ValidationException, ISkidlyException
{
    public InvalidEmailAddressException(string email) : base($"The '{email}' is not valid email address.")
    {
    }
}