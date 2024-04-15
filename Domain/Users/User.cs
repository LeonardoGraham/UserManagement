namespace Domain.Users;

public class User
{
    public Guid Id { get; private set;}

    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public DateTime DateOfBirth { get; private set; }

    public UserType UserType { get; private set; } = null!;

    public User(
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

    private User()
    {
    }
}