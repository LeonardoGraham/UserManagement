using Api.ApiEndpoints;
using Api.Mapping;
using Application.Users.Queries;
using Contracts.Users;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DomainUserType = Domain.Users.UserType;

namespace Api.Controllers;

public class UsersControllers(ISender sender) : ApiController
{
    [HttpPost(UsersEndpoints.Create)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (!DomainUserType.TryFromName(request.UserType,out var subscriptionType))
            return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Invalid user type");
        
        var command = request.ToCommand(subscriptionType);
        var result = await sender.Send(command, cancellationToken);

        return result.Match(
            user => CreatedAtAction(nameof(Get), new { id = user.Id }, user.ToResponse()),
            Problem);
    }

    [HttpGet(UsersEndpoints.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(id);
        var result = await sender.Send(query, cancellationToken);

        return result.Match(
            user => Ok(user.ToResponse()),
            Problem);
    }
}