namespace Skidly.Application.DTOs;

public record UserDto(
    string UserName,
    string Email,
    string? Fullname,
    string? DateOfBirth,
    string? Country);