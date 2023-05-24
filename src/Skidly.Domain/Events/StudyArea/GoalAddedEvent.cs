using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyArea;

public sealed record GoalAddedEvent(Aggregates.StudyArea StudyArea, Aggregates.StudyGoal Goal) : DomainEvent;