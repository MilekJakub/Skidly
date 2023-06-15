using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record StudyGoalCreatedEvent(Aggregates.StudyGoal StudyGoal) : DomainEvent;