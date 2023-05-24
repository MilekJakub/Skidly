using Microsoft.EntityFrameworkCore;
using Skidly.Application.DTOs;
using Skidly.Application.Users.GetUser;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework.Models;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Infrastructure.EntityFramework.Queries;

public class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly DbSet<ApplicationUserReadModel> _users;

    public GetUserHandler(DbSet<ApplicationUserReadModel> users)
    {
        _users = users;
    }

    public async Task<UserDto> Handle(GetUser request, CancellationToken cancellationToken)
    {
        var user = await _users.SingleOrDefaultAsync(u => request.Id == u.Id);

        if (user is null)
        {
            throw new Exception("UserNotFoundException");
        }
        
        var userDto = ReadModelMapper.UserDto(user);
        
        return userDto;
    }
}