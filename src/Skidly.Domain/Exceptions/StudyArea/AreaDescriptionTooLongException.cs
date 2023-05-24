using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyArea;

public sealed class AreaDescriptionTooLongException : SkidlyException
{
    public AreaDescriptionTooLongException() : base("The area description is too long (max 250 characters).")
    {
    }
}