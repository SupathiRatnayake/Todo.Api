using Todo.Application.Shared;
using Todo.Core.DTOs;

namespace Todo.Application.Interfaces
{
    public interface ITodoService
    {
        Task<Result<IEnumerable<TodoItemDto>>> GetAllTodosAsync();
        Task<Result<IEnumerable<TodoItemDto>>> GetAllTodosByOwnerAsync(Guid ownerId);
        Task<Result<TodoItemDto>> GetTodoByIdAsync(Guid id);
        Task<Result> AddOrUpdateTodoAsync(TodoItemDto todoDto);
        Task<Result> UpdateTodoAsync(TodoItemDto todoDto);
        Task<Result> DeleteTodoAsync(Guid id);
    }
}
