using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class DeadlineCannotBeInThePastException : ValidationException, ISkidlyException
{
    public DeadlineCannotBeInThePastException() : base("The deadline date cannot be in the past.")
    {
    }
}