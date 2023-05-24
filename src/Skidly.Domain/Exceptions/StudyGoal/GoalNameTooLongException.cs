using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class GoalNameTooLongException : SkidlyException
{
    public GoalNameTooLongException() : base("The goal name is too long (max 25 characters)")
    {
    }
}