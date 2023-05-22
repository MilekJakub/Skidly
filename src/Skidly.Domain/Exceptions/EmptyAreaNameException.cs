using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class EmptyAreaNameException : SkidlyException
{
    public EmptyAreaNameException() : base("The area name cannot be empty.")
    {
    }
}