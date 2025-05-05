using Todo.Application.Common;
using Todo.Application.DTOs;
using Todo.Application.Shared;

namespace Todo.Application.Interfaces
{
    public interface ITodoService
    {
        Task<Result<IEnumerable<TodoItemDto>>> GetAllTodosAsync();
        Task<Result<PagedList<TodoItemDto>>> GetAllTodosByOwnerAsync(Guid ownerId, PaginationParams paginationParams);
        Task<Result<TodoItemDto>> GetTodoByIdAsync(Guid id);
        Task<Result> AddOrUpdateTodoAsync(TodoItemDto todoDto);
        Task<Result> UpdateTodoAsync(TodoItemDto todoDto);
        Task<Result> DeleteTodoAsync(Guid id);
    }

}
