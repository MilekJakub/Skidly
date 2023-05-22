using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Events;

public sealed class GoalNotFoundException : SkidlyException
{
    public GoalNotFoundException() : base("The goal was not found.")
    {
    }
}