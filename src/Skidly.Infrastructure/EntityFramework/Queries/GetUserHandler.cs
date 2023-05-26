using Microsoft.EntityFrameworkCore;
using Skidly.Application.DTOs;
using Skidly.Application.Users.GetUser;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework.Models;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Infrastructure.EntityFramework.Queries;

public class GetUserHandler : IQueryHandler<GetUserRequest, UserDto>
{
    private readonly DbSet<ApplicationUserReadModel> _users;

    public GetUserHandler(DbSet<ApplicationUserReadModel> users)
    {
        _users = users;
    }

    public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _users.SingleOrDefaultAsync(u => request.Id == u.Id, cancellationToken: cancellationToken);

        if (user is null)
        {
            throw new Exception("UserNotFoundException");
        }
        
        var userDto = ReadModelMapper.UserDto(user);
        
        return userDto;
    }
}