using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.ComponentModel;
using Todo.Application.Interfaces;
using Todo.Core.DTOs;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ITodoService todoService) : ControllerBase
    {
        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> AddOrUpdateTodoAsync([FromBody] TodoItemDto itemDto)
        {
            var result = await todoService.AddOrUpdateTodoAsync(itemDto);
            return Ok(result);
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetTodosByOwnerAsync([FromQuery] Guid userId)
        {
            var result = await todoService.GetAllTodosByOwnerAsync(userId);
            return Ok(result);
        }

        [HttpGet("{todoId}")]
        [Authorize]
        public async Task<IActionResult> GetTodoById([FromRoute] Guid todoId)
        {
            var result = await todoService.GetTodoByIdAsync(todoId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{todoId}")]
        [Authorize]
        public async Task<IActionResult> UpdateTodoAsyncUp([FromRoute] Guid todoId, [FromBody] TodoItemDto todoDto)
        {
            if (todoId != todoDto.Id)  // checking if the id in the url is the same id in the object
            {
                return BadRequest();
            }
            var result = await todoService.UpdateTodoAsync(todoDto);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{todoId}")]
        [Authorize]
        public async Task<IActionResult> DeleteTodoAsync([FromRoute] Guid todoId)
        {
            var result = await todoService.DeleteTodoAsync(todoId);
            return Ok(result);
        }

        [HttpGet("testexception")]
        public async Task<bool> TestException()
        {
            throw new NotImplementedException();
        }
    }
}
