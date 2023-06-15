using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class EmptyCountryNameException : ValidationException, ISkidlyException
{
    public EmptyCountryNameException() : base($"The country code cannot be empty.")
    {
    }
}