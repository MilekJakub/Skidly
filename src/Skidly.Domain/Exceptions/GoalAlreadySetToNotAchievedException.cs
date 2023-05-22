using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public class GoalAlreadySetToNotAchievedException : SkidlyException
{
    public GoalAlreadySetToNotAchievedException() : base("The goal was already set as achieved.")
    {
    }
}