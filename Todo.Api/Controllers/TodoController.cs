using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;

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
        public async Task<IActionResult> GetTodosByOwnerAsync([FromQuery] Guid userId, [FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] FilterDTO filter)
        {
            var result = await todoService.GetFilteredTodosByOwnerAsync(
                userId,
                new PaginationParams
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                },
                filter);

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


        [HttpDelete("{todoId}")]
        [Authorize]
        public async Task<IActionResult> DeleteTodoAsync([FromRoute] Guid todoId)
        {
            var result = await todoService.DeleteTodoAsync(todoId);
            return Ok(result);
        }

        //[HttpGet("testexception")]
        //public async Task<bool> TestException()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
