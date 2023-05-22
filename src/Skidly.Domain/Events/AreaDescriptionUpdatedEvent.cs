using Skidly.Domain.Entities;
using Skidly.Domain.ValueObjects;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record AreaDescriptionUpdatedEvent(StudyArea StudyArea, AreaDescription Description) : DomainEvent;