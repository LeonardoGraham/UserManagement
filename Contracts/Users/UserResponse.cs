namespace Contracts.Users;

public record UserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth,
    string UserType);