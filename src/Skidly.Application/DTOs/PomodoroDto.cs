namespace Skidly.Application.DTOs;

public record PomodoroDto(
    string Topic,
    string ExpectedDuration,
    string Duration,
    string? StartTime,
    string? FinishTime,
    bool IsFinished,
    Guid GoalId);
