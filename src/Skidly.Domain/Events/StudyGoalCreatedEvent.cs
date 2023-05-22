using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record StudyGoalCreatedEvent(StudyGoal StudyGoal) : DomainEvent;