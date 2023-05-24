using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyArea;

public sealed record GoalRemovedEvent(Aggregates.StudyArea StudyArea, Aggregates.StudyGoal Goal) : DomainEvent;