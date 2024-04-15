namespace Api.ApiEndpoints;

public static class UsersEndpoints
{
    private const string Base = $"{Api.Base}/users";

    public const string Create = Base;
    public const string Get = $"{Base}/{{id:guid}}";
    public const string GetAll = Base;
}