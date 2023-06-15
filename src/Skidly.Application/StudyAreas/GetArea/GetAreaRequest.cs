using Skidly.Application.DTOs;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Application.StudyAreas.GetArea;

public record GetAreaRequest(Guid Id) : IQuery<StudyAreaDto>;