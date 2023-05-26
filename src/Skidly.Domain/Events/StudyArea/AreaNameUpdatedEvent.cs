using Skidly.Domain.ValueObjects.StudyArea;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events.StudyArea;

public sealed record AreaNameUpdatedEvent(Aggregates.StudyArea StudyArea, StudyAreaName StudyAreaName) : DomainEvent;