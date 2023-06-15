using Skidly.Domain.ValueObjects.StudyGoal;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record GoalPriorityUpdatedEvent(Aggregates.StudyGoal StudyGoal, GoalPriority Priority) : DomainEvent;