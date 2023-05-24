using Skidly.Domain.ValueObjects.StudyArea;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyArea;

public sealed record AreaDescriptionUpdatedEvent(Aggregates.StudyArea StudyArea, AreaDescription Description) : DomainEvent;