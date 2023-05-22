using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record GoalExpectedTimeToLearnUpdatedEvent(StudyGoal StudyGoal, TimeSpan ExpectedTimeToLearn) : DomainEvent;