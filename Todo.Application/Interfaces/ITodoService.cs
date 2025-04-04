using Todo.Application.Shared;
using Todo.Core.DTOs;

namespace Todo.Application.Interfaces
{
    public interface ITodoService
    {
        Task<Result<IEnumerable<TodoItemDto>>> GetAllTodosAsync();
        Task<Result<TodoItemDto>> GetTodoByIdAsync(Guid id);
        Task<Result<TodoItemDto>> AddTodoAsync(TodoItemDto todoDto);
        Task<Result> UpdateTodoAsync(TodoItemDto todoDto);
        Task<Result> DeleteTodoAsync(Guid id);
    }
}
