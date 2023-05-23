using Skidly.Domain.Constants;
using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record GoalCategoryUpdatedEvent(StudyGoal StudyGoal, GoalCategory Category) : DomainEvent;