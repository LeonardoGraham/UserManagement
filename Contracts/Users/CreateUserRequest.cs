namespace Contracts.Users;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth,
    string UserType);