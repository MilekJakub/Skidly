using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyArea;

public sealed class EmptyAreaNameException : ValidationException, ISkidlyException
{
    public EmptyAreaNameException() : base("The area name cannot be empty.")
    {
    }
}