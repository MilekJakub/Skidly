using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skidly.Application.StudyAreas.CreateArea;
using Skidly.Application.StudyAreas.GetArea;
using Skidly.Shared.Abstractions.API;

namespace Skidly.Api.Controllers;

[ApiController]
[Route("api/areas")]
public sealed class StudyAreaController : ApiController
{
    public StudyAreaController(ISender sender) : base(sender)
    {
    }

    [HttpGet("get/{Id}")]
    public async Task<IResult> GetAreaById([FromRoute] GetAreaRequest request, CancellationToken cancellationToken)
    {
        return Results.Ok(await Sender.Send(request, cancellationToken));
    }

    [HttpPost("create")]
    public async Task<IResult> CreateArea([FromBody] CreateAreaRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Created($"/api/areas/{request.Id}", null);
    }
}