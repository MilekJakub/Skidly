using Skidly.Shared.Abstractions.Commands;

namespace Skidly.Application.StudyGoals.CreateGoal;

public record CreateGoalRequest(
    Guid Id,
    string Name,
    string Description,
    string Category,
    byte Priority,
    TimeSpan? ExpectedLearningTime,
    DateTime? Deadline,
    bool IsAchieved,
    Guid AreaId) : ICommand;