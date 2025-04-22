using Todo.Core.DTOs;
using Todo.Core.Entities;

namespace Todo.Core.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync();
        Task<IEnumerable<TodoItemDto>> GetTodoItemsByOwnerAsync(Guid ownerId);
        Task<TodoItemDto?> GetTodoItemByIdAsync(Guid id);
        Task<TodoItemDto> AddTodoItemAsync(TodoItemDto todoDto);
        Task<TodoItemDto> AddOrUpDateTodoAsync(TodoItemDto todoDto);
        Task<TodoItemDto?> UpdateTodoItemAsync(TodoItemDto todoDto);
        Task<bool> DeleteTodoItemAsync(Guid id);
    }
}
