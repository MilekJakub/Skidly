namespace Skidly.Application.DTOs;

public record StudyGoalDto(
    string Name,
    string Description,
    string Category,
    byte Priority,
    string? ExpectedLearningTime,
    string? Deadline,
    bool IsAchieved,
    IEnumerable<PomodoroDto> Pomodoros,
    Guid AreaId);
