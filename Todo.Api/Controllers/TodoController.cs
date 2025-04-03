using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;
using Todo.Core.DTOs;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ITodoService todoService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddTodoAsync([FromBody] TodoItemDto itemDto)
        {
            var result = await todoService.AddTodoAsync(itemDto);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTodosAsync()
        {
            var result = await todoService.GetAllTodosAsync();
            return Ok(result);
        }

        [HttpGet("{todoId}")]
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
        public async Task<IActionResult> DeleteTodoAsync([FromRoute] Guid todoId)
        {
            var result = await todoService.DeleteTodoAsync(todoId);
            return Ok(result);
        }
    }
}
