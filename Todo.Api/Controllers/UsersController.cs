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
            var result = await sender.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new GetUserByIdQuery(userId));
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserasyncUp([FromRoute] Guid userId, [FromBody] UserEntity user)
        {
            if (userId != user.Id)  // checking if the id in the url is the same id in the object
            {
                return BadRequest();
            }
            var result = await sender.Send(new UpdateUserCommand(userId, user));

            if (result is null)
            {
                return NotFound();
            }

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
