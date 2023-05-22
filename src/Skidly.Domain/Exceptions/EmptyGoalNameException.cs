using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class EmptyGoalNameException : SkidlyException
{
    public EmptyGoalNameException() : base("The goal name cannot be empty.")
    {
    }
}