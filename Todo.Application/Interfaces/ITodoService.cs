using Todo.Core.DTOs;

namespace Todo.Application.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>> GetAllTodosAsync();
        Task<TodoItemDto?> GetTodoByIdAsync(Guid id);
        Task<TodoItemDto> AddTodoAsync(TodoItemDto todoDto);
        Task<TodoItemDto?> UpdateTodoAsync(TodoItemDto todoDto);
        Task<bool> DeleteTodoAsync(Guid id);
    }
}
