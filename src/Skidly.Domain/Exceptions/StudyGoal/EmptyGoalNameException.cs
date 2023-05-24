using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class EmptyGoalNameException : SkidlyException
{
    public EmptyGoalNameException() : base("The goal name cannot be empty.")
    {
    }
}