using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class InvalidBirthDateException : ValidationException, ISkidlyException
{
    public InvalidBirthDateException(string date) : base($"The birth date '{date}' is in the past.")
    {
    }
}