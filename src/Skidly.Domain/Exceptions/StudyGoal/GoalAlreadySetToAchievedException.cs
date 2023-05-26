using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class GoalAlreadySetToAchievedException : ValidationException, ISkidlyException
{
    public GoalAlreadySetToAchievedException() : base("The goal was already set as achieved.")
    {
    }
}