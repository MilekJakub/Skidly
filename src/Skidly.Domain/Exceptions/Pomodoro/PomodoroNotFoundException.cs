using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.Pomodoro;

public sealed class PomodoroNotFoundException : SkidlyException
{
    public PomodoroNotFoundException() : base("The pomodoro was not found.")
    {
    }
}