﻿using Skidly.Domain.Entities;
using Skidly.Shared.Abstractions.Domain;

namespace Skidly.Domain.Events;

public sealed record StudyAreaCreatedEvent(StudyArea StudyArea) : DomainEvent;