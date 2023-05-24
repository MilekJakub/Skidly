using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.Pomodoro;

public sealed record PomodoroStartTimeSetEvent(Entities.Pomodoro Pomodoro, DateTime StartTime) : DomainEvent;