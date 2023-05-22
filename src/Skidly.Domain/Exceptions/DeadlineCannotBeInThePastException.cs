using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class DeadlineCannotBeInThePastException : SkidlyException
{
    public DeadlineCannotBeInThePastException() : base("The deadline date cannot be in the past.")
    {
    }
}