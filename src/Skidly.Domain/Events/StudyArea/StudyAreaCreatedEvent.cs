using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyArea;

public sealed record StudyAreaCreatedEvent(Aggregates.StudyArea StudyArea) : DomainEvent;