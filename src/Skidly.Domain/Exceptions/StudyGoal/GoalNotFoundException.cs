using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class GoalNotFoundException : SkidlyException
{
    public GoalNotFoundException() : base("The goal was not found.")
    {
    }
}