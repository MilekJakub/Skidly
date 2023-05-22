using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class EmptyPomodoroTopicException : SkidlyException
{
    public EmptyPomodoroTopicException() : base("The pomodoro topic cannot be empty.")
    {
    }
}