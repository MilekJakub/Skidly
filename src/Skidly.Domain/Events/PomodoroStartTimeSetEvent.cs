using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record PomodoroStartTimeSetEvent(Pomodoro Pomodoro, DateTime StartTime) : DomainEvent;