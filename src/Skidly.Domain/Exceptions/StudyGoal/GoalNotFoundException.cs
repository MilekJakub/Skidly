using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class GoalNotFoundException : NotFoundException, ISkidlyException
{
    public GoalNotFoundException() : base("The goal was not found.")
    {
    }
}