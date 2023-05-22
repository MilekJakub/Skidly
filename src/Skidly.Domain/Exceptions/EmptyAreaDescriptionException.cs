using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class EmptyAreaDescriptionException : SkidlyException
{
    public EmptyAreaDescriptionException() : base("The area description cannot be empty.")
    {
    }
}