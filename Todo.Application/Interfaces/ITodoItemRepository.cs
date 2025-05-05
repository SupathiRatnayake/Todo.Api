using Todo.Application.Common;
using Todo.Application.DTOs;


namespace Todo.Application.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync();
        Task<PagedList<TodoItemDto>> GetTodoItemsByOwnerAsync(Guid ownerId, PaginationParams paginationParams);
        Task<TodoItemDto?> GetTodoItemByIdAsync(Guid id);
        Task<TodoItemDto> AddTodoItemAsync(TodoItemDto todoDto);
        Task<TodoItemDto> AddOrUpDateTodoAsync(TodoItemDto todoDto);
        Task<TodoItemDto?> UpdateTodoItemAsync(TodoItemDto todoDto);
        Task<bool> DeleteTodoItemAsync(Guid id);
    }
}
