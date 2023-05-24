using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.Pomodoro;

public sealed record PomodoroEndTimeSetEvent(Entities.Pomodoro Pomodoro, DateTime EndTime) : DomainEvent;