using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyGoal;

public sealed record GoalExpectedTimeToLearnUpdatedEvent(Aggregates.StudyGoal StudyGoal, TimeSpan ExpectedTimeToLearn) : DomainEvent;