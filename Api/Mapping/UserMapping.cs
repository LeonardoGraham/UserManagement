using Application.Users.Commands;
using Contracts.Users;
using Domain.Users;

namespace Api.Mapping;

public static class UserMapping
{
    public static CreateUserCommand ToCommand(
        this CreateUserRequest request,
        UserType userType)
    {
        return new CreateUserCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.DateOfBirth,
            userType);
    }

    public static UserResponse ToResponse(this User user)
    {
        return new UserResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.DateOfBirth,
            user.UserType.Name);
    }
}