using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.Pomodoro;

public sealed class PomodoroNotFoundException : NotFoundException, ISkidlyException
{
    public PomodoroNotFoundException() : base("The pomodoro was not found.")
    {
    }
}