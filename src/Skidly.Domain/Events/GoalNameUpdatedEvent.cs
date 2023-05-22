using Skidly.Domain.Entities;
using Skidly.Domain.ValueObjects;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record GoalNameUpdatedEvent(StudyGoal StudyGoal, GoalName GoalName) : DomainEvent;