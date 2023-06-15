using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class GoalDescriptionTooLongException : ValidationException, ISkidlyException
{
    public GoalDescriptionTooLongException() : base("The goal description is too long (max 250 characters)")
    {
    }
}