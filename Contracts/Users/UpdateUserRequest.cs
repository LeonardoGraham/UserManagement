namespace Contracts.Users;

public record UpdateUserRequest(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth,
    string UserType);