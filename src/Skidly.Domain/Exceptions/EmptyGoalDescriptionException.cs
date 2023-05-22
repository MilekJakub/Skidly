using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class EmptyGoalDescriptionException : SkidlyException
{
    public EmptyGoalDescriptionException() : base("The goal description cannot be empty.")
    {
    }
}