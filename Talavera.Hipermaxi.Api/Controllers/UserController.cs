using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Talavera.Hipermaxi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _sender.Send(new Application.Users.GetUser.GetUserQuery(id));
        return user.IsSuccess ? Ok(user.Value) : NotFound(user.Error);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string sortBy,
        [FromQuery] string sortOrder)
    {
        var users = await _sender.Send(
            new Application.Users.GetUsers.GetUsersQuery(page, pageSize, sortBy, sortOrder));

        Response.Headers.Append("X-Metadata", JsonSerializer.Serialize(users.Value.Count));

        return users.IsSuccess ? Ok(users.Value.Items) : BadRequest(users.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserRequest request)
    {
        var user = await _sender.Send(new Application.Users.CreateUser.CreateUserCommand(request.Name,
            request.BirthDate, request.Profession, request.Nationality, request.PhoneNumber, request.Email,
            request.Salary));
        if (!user.IsSuccess)
        {
            return BadRequest(user.Error);
        }

        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UserRequest request)
    {
        var user = await _sender.Send(new Application.Users.UpdateUser.UpdateUserCommand(id, request.Name,
            request.BirthDate, request.Profession, request.Nationality, request.PhoneNumber, request.Email,
            request.Salary));
        return user.IsSuccess ? Ok(user.Value) : BadRequest(user.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _sender.Send(new Application.Users.DeleteUser.DeleteUserCommand(id));
        if (!user.IsSuccess)
        {
            return BadRequest(user.Error);
        }

        return NoContent();
    }
}