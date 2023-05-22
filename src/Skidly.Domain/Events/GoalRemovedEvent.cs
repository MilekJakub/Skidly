using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record GoalRemovedEvent(StudyArea StudyArea, StudyGoal Goal) : DomainEvent;