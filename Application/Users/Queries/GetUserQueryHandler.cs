using Application.Users.Common.Interfaces;
using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Users.Queries;

public class GetUserQueryHandler(IUsersRepository usersRepository) : IRequestHandler<GetUserQuery, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
            return Error.NotFound(description: "User not found");

        return user;
    }
}