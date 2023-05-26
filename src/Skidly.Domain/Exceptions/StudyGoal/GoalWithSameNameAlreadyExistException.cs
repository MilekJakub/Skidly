using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class GoalWithSameNameAlreadyExistException : ValidationException, ISkidlyException
{
    public GoalWithSameNameAlreadyExistException(string name) : base($"The goal with name '{name}' already exists.")
    {
    }
}