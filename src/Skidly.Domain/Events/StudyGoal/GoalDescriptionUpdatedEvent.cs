using Skidly.Domain.ValueObjects.StudyGoal;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record GoalDescriptionUpdatedEvent(Aggregates.StudyGoal StudyGoal, StudyGoalDescription Description) : DomainEvent;