using Ardalis.SmartEnum;

namespace Domain.Users;

public class UserType(string name, int value) : SmartEnum<UserType>(name, value)
{
    public static readonly UserType Standard = new(nameof(Standard), 0);
    public static readonly UserType Manager = new(nameof(Manager), 1);
    public static readonly UserType Admin = new(nameof(Admin), 2);
}