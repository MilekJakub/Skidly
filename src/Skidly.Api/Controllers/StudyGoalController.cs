using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skidly.Application.StudyGoals.CreateGoal;
using Skidly.Application.StudyGoals.GetGoal;
using Skidly.Shared.Abstractions.API;

namespace Skidly.Api.Controllers;

[ApiController]
[Route("api/goals")]
public sealed class StudyGoalController : ApiController
{
    public StudyGoalController(ISender sender) : base(sender)
    {
    }

    [HttpGet("get/{Id}")]
    public async Task<IResult> GetAreaById([FromRoute] GetGoalRequest request, CancellationToken cancellationToken)
    {
        return Results.Ok(await Sender.Send(request, cancellationToken));
    }

    [HttpPost("create")]
    public async Task<IResult> CreateArea([FromBody] CreateGoalRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Created($"/api/areas/{request.Id}", null);
    }
}
