using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class FullnameTooLongException : ValidationException, ISkidlyException
{
    public FullnameTooLongException(string fullname) : base($"The fullname '{fullname} is too long. Max fullname length is 100.")
    {
    }
}