using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.Pomodoro;

public sealed record PomodoroExpectedDurationUpdatedEvent(Entities.Pomodoro Pomodoro, TimeSpan ExpectedDuration) : DomainEvent;