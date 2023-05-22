using Skidly.Domain.Entities;
using Skidly.Domain.Enums;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record GoalCategoryUpdatedEvent(StudyGoal StudyGoal, GoalCategory Category) : DomainEvent;