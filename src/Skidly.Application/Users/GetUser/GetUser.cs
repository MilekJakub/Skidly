using Skidly.Application.DTOs;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Application.Users.GetUser;

public record GetUser(Guid Id) : IQuery<UserDto>;