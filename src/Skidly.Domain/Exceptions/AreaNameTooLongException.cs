using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class AreaNameTooLongException : SkidlyException
{
    public AreaNameTooLongException() : base("The area name is too long (max 25 characters)")
    {
    }
}