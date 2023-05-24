using Skidly.Shared.Abstractions.Commands;

namespace Skidly.Application.Users.LoginUser;

public class LoginUserHandler : ICommandHandler<LoginUser>
{
    public Task Handle(LoginUser request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}