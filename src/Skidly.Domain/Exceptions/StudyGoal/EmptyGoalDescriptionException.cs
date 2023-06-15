using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class EmptyGoalDescriptionException : ValidationException, ISkidlyException
{
    public EmptyGoalDescriptionException() : base("The goal description cannot be empty.")
    {
    }
}