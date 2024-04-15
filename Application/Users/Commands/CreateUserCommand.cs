using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Users.Commands;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth,
    UserType UserType) : IRequest<ErrorOr<User>>;