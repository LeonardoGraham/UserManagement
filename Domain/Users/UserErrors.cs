using ErrorOr;

namespace Domain.Users;

public static class UserErrors
{
    public static readonly Error AlreadyAnAdmin = Error.Validation(
        code: "User.AlreadyAnAdmin",
        description: "User is already an admin");

    public static readonly Error InvalidEmailDomainForAdminAccess = Error.Validation(
        code: "User.InvalidEmailDomainForAdminAccess",
        description: "Only users with emails with 'test.com' domain can be set to Admin");

    public static readonly Error EmailNotValid = Error.Unexpected(
        code: "User.EmailNotValid",
        description: "Expected email to contain '@' character");
}