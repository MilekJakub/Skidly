using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyGoal;

public sealed class InvalidPriorityException : ValidationException, ISkidlyException
{ 
    public InvalidPriorityException() : base("The priority can only be a number from 1-10 range.")
    {
    }
}