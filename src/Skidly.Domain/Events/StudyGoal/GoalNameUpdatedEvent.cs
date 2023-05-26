using Skidly.Domain.ValueObjects.StudyGoal;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record GoalNameUpdatedEvent(Aggregates.StudyGoal StudyGoal, StudyGoalName StudyGoalName) : DomainEvent;