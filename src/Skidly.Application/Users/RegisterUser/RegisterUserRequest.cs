using Skidly.Shared.Abstractions.Commands;

namespace Skidly.Application.Users.RegisterUser;

public sealed class RegisterUserRequest : ICommand
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public Guid RoleId { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string? Fullname { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Country { get; set; }
}