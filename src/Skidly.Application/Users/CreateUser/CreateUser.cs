using Skidly.Domain.Entities;
using Skidly.Domain.ValueObjects;
using Skidly.Shared.Abstractions.Commands;

namespace Skidly.Application.Users.CreateUser;

public sealed record CreateUser(
    Guid Id,
    Username Username,
    string Password,
    EmailAddress EmailAddress,
    Fullname? Fullname,
    DateOfBirth DateOfBirth,
    Country Country)
    : ICommand;