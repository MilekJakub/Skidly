using Skidly.Application.Users.LoginUser;
using Skidly.Application.Users.RegisterUser;

namespace Skidly.Application.Services;

public interface IAuthService
{
        Task<LoginUserResponse> Login(LoginUserRequest request, CancellationToken cancellationToken = default);
        Task<RegisterUserResponse> Register(RegisterUserRequest request, CancellationToken cancellationToken = default);
}