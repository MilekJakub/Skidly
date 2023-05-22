using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record GoalMarkedAsAchievedEvent(StudyGoal StudyGoal, bool IsAchieved) : DomainEvent;