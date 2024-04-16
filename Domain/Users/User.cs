using System.Text.RegularExpressions;
using ErrorOr;
using Throw;

namespace Domain.Users;

public partial class User
{
    public Guid Id { get; private set;}

    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public DateTime DateOfBirth { get; private set; }

    public UserType UserType { get; private set; } = null!;

    private User(
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth,
        UserType userType,
        Guid? id = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dateOfBirth;
        UserType = userType;
        Id = id ?? Guid.NewGuid();
    }

    public static ErrorOr<User> Create(
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth,
        UserType userType,
        Guid? id = null)
    {
        var emailDomainName = ParseDomainFromEmail(email);

        if (emailDomainName is null)
            // emailDomainName.ThrowIfNull();
            return UserErrors.EmailNotValid;

        if (userType == UserType.Admin && email != "test.com")
            return UserErrors.InvalidEmailDomainForAdminAccess;
        
        var user = new User(
            firstName,
            lastName,
            email,
            dateOfBirth,
            userType,
            id);
        
        return user;
    }
    
    public ErrorOr<Success> SetToAdmin()
    {
        if (UserType.Equals(UserType.Admin))
            return UserErrors.AlreadyAnAdmin;
        
        UserType = UserType.Admin;

        return Result.Success;
    }
    
    private static string? ParseDomainFromEmail(string email)
    {
        var match = MyRegex().Match(email);

        return match.Success 
            ? match.Groups[1].Value 
            : null;
    }
    
    private User()
    {
    }

    [GeneratedRegex(@"@([a-zA-Z0-9\-\.]+)$")]
    private static partial Regex MyRegex();
}