using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record PomodoroAddedToGoalEvent(StudyGoal Goal, Pomodoro Pomodoro) : DomainEvent;