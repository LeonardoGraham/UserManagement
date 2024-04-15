using Api.ApiEndpoints;
using Api.Mapping;
using Application.Users.Queries;
using Contracts.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainUserType = Domain.Users.UserType;

namespace Api.Controllers;

[ApiController]
public class UsersControllers(ISender sender) : ControllerBase
{
    [HttpPost(UsersEndpoints.Create)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (!DomainUserType.TryFromName(
                request.UserType.ToString(),
                out var subscriptionType))
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid user type");
        }
        
        var command = request.ToCommand(subscriptionType);
        var result = await sender.Send(command, cancellationToken);

        return result.Match(
            user => CreatedAtAction(
                nameof(Get),
                new { id = user.Id }, 
                user.ToResponse()),
            _ => Problem());
    }

    [HttpGet(UsersEndpoints.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(id);
        var result = await sender.Send(query, cancellationToken);

        return result.MatchFirst(
            user => Ok(user.ToResponse()),
            _ => Problem());
    }
}