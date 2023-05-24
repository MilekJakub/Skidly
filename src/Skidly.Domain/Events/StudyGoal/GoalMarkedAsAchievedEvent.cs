using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record GoalMarkedAsAchievedEvent(Aggregates.StudyGoal StudyGoal, bool IsAchieved) : DomainEvent;