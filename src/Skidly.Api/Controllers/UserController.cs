using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skidly.Application.Services;
using Skidly.Application.Users.GetAllUsers;
using Skidly.Application.Users.GetUser;
using Skidly.Shared.Abstractions.API;

namespace Skidly.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UserController : ApiController
{
    private readonly IUserRepository _userRepository;
    
    public UserController(ISender sender, IUserRepository userRepository) : base(sender)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet("get/{Id}")]
    [Authorize]
    public async Task<IResult> GetUserById([FromRoute] GetUserRequest request, CancellationToken cancellationToken)
    {
        return Results.Ok(await Sender.Send(request, cancellationToken));
    }
    
    [HttpGet("get/all")]
    [Authorize(Roles = "Administrator")]
    public async Task<IResult> GetAllUsers(CancellationToken cancellationToken)
    {
        return Results.Ok(await Sender.Send(new GetAllUsersRequest(), cancellationToken));
    }
}
