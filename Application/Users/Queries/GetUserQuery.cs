using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Users.Queries;

public record GetUserQuery(Guid Id)
    : IRequest<ErrorOr<User>>;