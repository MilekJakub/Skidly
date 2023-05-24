using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record PomodoroRemovedFromGoalEvent(Aggregates.StudyGoal StudyGoal, Entities.Pomodoro Pomodoro) : DomainEvent;