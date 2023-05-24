using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.Pomodoro;

public sealed record PomodoroCreatedEvent(Entities.Pomodoro Pomodoro) : DomainEvent;