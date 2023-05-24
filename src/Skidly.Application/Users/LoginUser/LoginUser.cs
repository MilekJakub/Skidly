using System.Windows.Input;
using ICommand = Skidly.Shared.Abstractions.Commands.ICommand;

namespace Skidly.Application.Users.LoginUser;

public record LoginUser(string Username, string Password) : ICommand;