using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class GoalWithSameNameAlreadyExistException : SkidlyException
{
    public GoalWithSameNameAlreadyExistException(string name) : base($"The goal with name '{name}' already exists.")
    {
    }
}