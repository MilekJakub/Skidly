using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Skidly.Shared.Abstractions.API;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}