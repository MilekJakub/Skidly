using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record PomodoroAddedToGoalEvent(Aggregates.StudyGoal Goal, Entities.Pomodoro Pomodoro) : DomainEvent;