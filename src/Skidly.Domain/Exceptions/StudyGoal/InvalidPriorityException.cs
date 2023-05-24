using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class InvalidPriorityException : SkidlyException
{ 
    public InvalidPriorityException() : base("The priority can only be a number from 1-10 range.")
    {
    }
}