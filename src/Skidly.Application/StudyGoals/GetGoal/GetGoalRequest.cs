using Skidly.Application.DTOs;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Application.StudyGoals.GetGoal;

public record GetGoalRequest(Guid Id) : IQuery<StudyGoalDto>;