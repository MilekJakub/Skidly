using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class InvalidCountryCodeException : ValidationException, ISkidlyException
{
    public InvalidCountryCodeException(string code) : base($"The country code '{code}' is not valid.")
    {
    }
}