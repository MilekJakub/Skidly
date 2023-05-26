using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyArea;

public sealed class EmptyAreaDescriptionException : ValidationException, ISkidlyException
{
    public EmptyAreaDescriptionException() : base("The area description cannot be empty.")
    {
    }
}