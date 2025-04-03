using Microsoft.EntityFrameworkCore;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories
{
    internal class TodoItemRepository(AppDbContext dbContext) : ITodoItemRepository
    {
        public async Task<TodoItemEntity> AddTodoItemAsync(TodoItemEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Todos.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteTodoItemAsync(Guid id)
        {
            var todo = await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo is not null)
            {
                dbContext.Todos.Remove(todo);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<TodoItemEntity?> GetTodoItemByIdAsync(Guid id)
        {
            return await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TodoItemEntity>> GetTodoItems()
        {
            return await dbContext.Todos.ToListAsync();
        }

        public async Task<TodoItemEntity> UpdateTodoItemAsync(Guid todoId, TodoItemEntity entity)
        {
            var todo = await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == todoId);
            if (todo is not null)
            {
                todo.Title = entity.Title;
                todo.Description = entity.Description;
                todo.DueDate = entity.DueDate;
                todo.IsComplete = entity.IsComplete;
                todo.IsDeleted = entity.IsDeleted;

                await dbContext.SaveChangesAsync();
                return todo;
            }

            return entity;
        }
    }
}
