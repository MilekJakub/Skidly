using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class GoalDescriptionTooLongException : SkidlyException
{
    public GoalDescriptionTooLongException() : base("The goal description is too long (max 250 characters)")
    {
    }
}