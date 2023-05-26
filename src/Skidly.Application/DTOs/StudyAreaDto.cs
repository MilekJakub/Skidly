namespace Skidly.Application.DTOs;

public record StudyAreaDto(
    string Name,
    string Description,
    IEnumerable<StudyGoalDto> Goals,
    string OwnerId);