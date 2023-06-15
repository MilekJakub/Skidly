using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class EmptyGoalNameException : ValidationException, ISkidlyException
{
    public EmptyGoalNameException() : base("The goal name cannot be empty.")
    {
    }
}