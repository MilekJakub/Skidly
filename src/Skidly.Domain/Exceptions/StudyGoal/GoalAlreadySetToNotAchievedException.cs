using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public class GoalAlreadySetToNotAchievedException : ValidationException, ISkidlyException
{
    public GoalAlreadySetToNotAchievedException() : base("The goal was already set as achieved.")
    {
    }
}