using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record GoalMarkedAsNotAchievedEvent(Aggregates.StudyGoal StudyGoal, bool IsAchieved) : DomainEvent;