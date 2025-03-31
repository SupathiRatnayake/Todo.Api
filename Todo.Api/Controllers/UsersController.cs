using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Commands;
using Todo.Application.Queries;
using Todo.Core.Entities;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddUserasync([FromBody] UserEntity user)
        {
            var result = await sender.Send(new AddUserCommand(user));
            return Ok(result); 
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsersasync()
        {
            var result = await sender.Send(new GetallUsersQuery());
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByGetUserByIdAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new GetUserByIdQuery(userId));
            return Ok(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserasyncUp([FromRoute] Guid userId, [FromBody] UserEntity user)
        {
            var result = await sender.Send(new UpdateUserCommand(userId, user));
            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new DeleteUserCommand(userId));
            return Ok(result);
        }

        
    }
}
