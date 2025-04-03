using Todo.Core.Entities;

namespace Todo.Core.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItemEntity>> GetTodoItems();
        Task<TodoItemEntity?> GetTodoItemByIdAsync(Guid id);
        Task<TodoItemEntity> AddTodoItemAsync(TodoItemEntity entity);
        Task<TodoItemEntity> UpdateTodoItemAsync(Guid todoId, TodoItemEntity entity);
        Task<bool> DeleteTodoItemAsync(Guid id);
    }
}
