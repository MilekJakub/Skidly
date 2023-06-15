using Skidly.Shared.Abstractions.Commands;

namespace Skidly.Application.StudyAreas.CreateArea;

public record CreateAreaRequest(
    Guid Id,
    string Name,
    string Description,
    string UserId) : ICommand;