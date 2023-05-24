using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.Pomodoro;

public sealed record PomodoroDurationIncreasedEvent(Entities.Pomodoro Pomodoro, TimeSpan Duration) : DomainEvent;