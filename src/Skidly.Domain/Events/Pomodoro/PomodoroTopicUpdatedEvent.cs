using Skidly.Domain.ValueObjects.Pomodoro;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.Pomodoro;

public sealed record PomodoroTopicUpdatedEvent(Entities.Pomodoro Pomodoro, PomodoroTopic Topic) : DomainEvent;