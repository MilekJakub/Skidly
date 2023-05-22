using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record PomodoroDurationIncreasedEvent(Pomodoro Pomodoro, TimeSpan Duration) : DomainEvent;