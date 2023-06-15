using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyArea;

public sealed class AreaNameTooLongException : ValidationException, ISkidlyException
{
    public AreaNameTooLongException() : base("The area name is too long (max 25 characters)")
    {
    }
}