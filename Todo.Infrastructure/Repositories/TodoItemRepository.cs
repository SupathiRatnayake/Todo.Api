using Microsoft.EntityFrameworkCore;
using Todo.Core.DTOs;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories
{
    internal class TodoItemRepository(AppDbContext dbContext) : ITodoItemRepository
    {
        /* Add */
        public async Task<TodoItemDto> AddTodoItemAsync(TodoItemDto todoDto)
        {
            var todoEntity = new TodoItemEntity
            {
                Title = todoDto.Title,
                Description = todoDto.Description,
                DueDate = todoDto.DueDate,
                IsComplete = todoDto.IsComplete,
                IsDeleted = todoDto.IsDeleted,
                OwnerId = todoDto.OwnerId,
            };

            dbContext.Todos.Add(todoEntity);
            await dbContext.SaveChangesAsync();

            return new TodoItemDto
            {
                Id = todoEntity.Id,
                Title = todoEntity.Title,
                Description = todoEntity.Description,
                DueDate = todoEntity.DueDate,
                IsComplete = todoEntity.IsComplete,
                IsDeleted = todoEntity.IsDeleted,
                OwnerId = todoEntity.OwnerId,
            };
        }

        /* Delete */
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

        /* Update */
        public async Task<TodoItemDto?> UpdateTodoItemAsync(TodoItemDto todoDto)
        {
            var todo = await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == todoDto.Id);
            if (todo is not null)
            {
                todo.Title = todoDto.Title;
                todo.Description = todoDto.Description;
                todo.DueDate = todoDto.DueDate;
                todo.IsComplete = todoDto.IsComplete;
                todo.IsDeleted = todoDto.IsDeleted;

                await dbContext.SaveChangesAsync();
                return new TodoItemDto
                { 
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    DueDate = todo.DueDate,
                    IsComplete = todo.IsComplete,
                    IsDeleted = todo.IsDeleted,
                    OwnerId = todo.OwnerId,
                };
            }
            return null;
        }

        /* Get By Id */
        public async Task<TodoItemDto?> GetTodoItemByIdAsync(Guid id)
        {
            var todo = await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo is not null)
            {
                return new TodoItemDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    DueDate = todo.DueDate,
                    IsComplete = todo.IsComplete,
                    IsDeleted = todo.IsDeleted,
                    OwnerId = todo.OwnerId,
                };
            }
            return null;

        }

        /* Get All */
        public async Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync()
        {
            return await dbContext.Todos.Select(t => new TodoItemDto 
            { 
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate= t.DueDate,
                IsComplete = t.IsComplete,
                IsDeleted = t.IsDeleted,
                OwnerId = t.OwnerId,
            }).ToListAsync();
        }

        public async Task<IEnumerable<TodoItemDto>> GetTodoItemsByOwnerAsync(Guid ownerId)
        {
            return await dbContext.Todos
                .Where(t => t.OwnerId == ownerId)
                .Select(t => new TodoItemDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                IsComplete = t.IsComplete,
                IsDeleted = t.IsDeleted,
                OwnerId = t.OwnerId,
            }).ToListAsync();
        }

        public async Task<TodoItemDto> AddOrUpDateTodoAsync(TodoItemDto todoDto)
        {
            if (todoDto.Id != Guid.Empty)
            {
                var todo = await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == todoDto.Id);
                if (todo is not null)
                {
                    todo.Title = todoDto.Title;
                    todo.Description = todoDto.Description;
                    todo.DueDate = todoDto.DueDate;
                    todo.IsComplete = todoDto.IsComplete;
                    todo.IsDeleted = todoDto.IsDeleted;

                    await dbContext.SaveChangesAsync();
                    return new TodoItemDto
                    {
                        Id = todo.Id,
                        Title = todo.Title,
                        Description = todo.Description,
                        DueDate = todo.DueDate,
                        IsComplete = todo.IsComplete,
                        IsDeleted = todo.IsDeleted,
                        OwnerId = todo.OwnerId,
                    };
                }
            }
            var todoEntity = new TodoItemEntity
            {
                Title = todoDto.Title,
                Description = todoDto.Description,
                DueDate = todoDto.DueDate,
                IsComplete = todoDto.IsComplete,
                IsDeleted = todoDto.IsDeleted,
                OwnerId = todoDto.OwnerId,
            };

            dbContext.Todos.Add(todoEntity);
            await dbContext.SaveChangesAsync();

            return new TodoItemDto
            {
                Id = todoEntity.Id,
                Title = todoEntity.Title,
                Description = todoEntity.Description,
                DueDate = todoEntity.DueDate,
                IsComplete = todoEntity.IsComplete,
                IsDeleted = todoEntity.IsDeleted,
                OwnerId = todoEntity.OwnerId,
            };

        }
    }
}
 