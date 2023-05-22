using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions;

public sealed class PomodoroTopicTooLongException : SkidlyException
{
    public PomodoroTopicTooLongException() : base("The pomodoro topic is too long (max 25 characters)")
    {
    }
}