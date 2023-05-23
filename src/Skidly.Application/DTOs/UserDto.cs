namespace Skidly.Application.DTOs;

public record UserDto(
    string Username,
    string Email,
    string? Fullname,
    string? DateOfBirth,
    string? Country);