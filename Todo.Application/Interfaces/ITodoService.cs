using Todo.Application.Common;
using Todo.Application.DTOs;
using Todo.Application.Shared;

namespace Todo.Application.Interfaces
{
    public interface ITodoService
    {
        Task<Result<IEnumerable<TodoItemDto>>> GetAllTodosAsync();
        Task<Result<PagedList<TodoItemDto>>> GetFilteredTodosByOwnerAsync(Guid ownerId, PaginationParams paginationParams, FilterDTO filter);
        Task<Result<TodoItemDto>> GetTodoByIdAsync(Guid id);
        Task<Result> AddOrUpdateTodoAsync(TodoItemDto todoDto);
        Task<Result> DeleteTodoAsync(Guid id);
    }

}
