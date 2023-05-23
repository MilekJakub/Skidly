using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skidly.Application.DTOs;
using Skidly.Application.Users.CreateUser;
using Skidly.Application.Users.GetUser;
using Skidly.Shared.Abstractions.API;

namespace Skidly.Api.Controllers;

[Route("api/users")]
public sealed class UsersController : ApiController
{
    public UsersController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<IResult> GetUser([FromBody] GetUser request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return Results.Ok(result);
    }

    [HttpPost]
    public async Task<IResult> RegisterUser([FromBody] CreateUser request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Created($"/api/users/{request.Id}", null);
    }
}