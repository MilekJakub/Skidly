using Skidly.Domain.Constants;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record GoalCategoryUpdatedEvent(Aggregates.StudyGoal StudyGoal, GoalCategory Category) : DomainEvent;