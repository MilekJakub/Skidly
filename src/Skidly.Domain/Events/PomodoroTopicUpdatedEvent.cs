using Skidly.Domain.Entities;
using Skidly.Domain.ValueObjects;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record PomodoroTopicUpdatedEvent(Pomodoro Pomodoro, PomodoroTopic Topic) : DomainEvent;