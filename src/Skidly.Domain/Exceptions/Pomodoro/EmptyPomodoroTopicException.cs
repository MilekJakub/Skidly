using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.Pomodoro;

public sealed class EmptyPomodoroTopicException : ValidationException, ISkidlyException
{
    public EmptyPomodoroTopicException() : base("The pomodoro topic cannot be empty.")
    {
    }
}