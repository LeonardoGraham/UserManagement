using Application.Users.Common.Interfaces;
using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Users.Commands;

public class CreateUserCommandHandler(
    IUsersRepository usersRepository, 
    IUnitOfWork unitOfWork): IRequestHandler<CreateUserCommand, ErrorOr<User>>
{

    public async Task<ErrorOr<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // create user
        var user = new User(
            request.FirstName,
            request.LastName,
            request.Email,
            request.DateOfBirth,
            request.UserType);

        // Add it to the database
        await usersRepository.AddUserAsync(user, cancellationToken);
        
        // Commit all repository changes - used when modifying more than 1 repository. 
        await unitOfWork.CommitChangesAsync(cancellationToken);
        
        // Return userId
        return user;
    }
}