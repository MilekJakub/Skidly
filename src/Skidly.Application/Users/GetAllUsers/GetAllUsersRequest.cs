using Skidly.Application.DTOs;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Application.Users.GetAllUsers;

public record GetAllUsersRequest() : IQuery<IEnumerable<UserDto>>;