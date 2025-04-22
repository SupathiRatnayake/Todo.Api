using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Interfaces;
using Todo.Application.Shared;
using Todo.Core.DTOs;
using Todo.Core.Interfaces;

namespace Todo.Application.Services
{
    public class TodoService(ITodoItemRepository todoRepository) : ITodoService
    {
        public async Task<Result> AddOrUpdateTodoAsync(TodoItemDto todoDto)
        {
            var existingTodo = await todoRepository.GetTodoItemByIdAsync(todoDto.Id);
            if (existingTodo != null)
            {
                // Update existing TodoEntity
                var updatedTodo = await todoRepository.UpdateTodoItemAsync(todoDto);
                if (updatedTodo is null)
                {
                    return await Task.FromResult(Result.Failure("Unable to update."));
                }
                return await Task.FromResult(Result.Success(updatedTodo));
            }
            var result = await todoRepository.AddTodoItemAsync(todoDto);
            if (result is null)
            {
                return await Task.FromResult(Result.Failure("Unable to create."));
            }
            return await Task.FromResult(Result.Success(result));
        }

        public async Task<Result> DeleteTodoAsync(Guid id)
        {
            var result = await todoRepository.DeleteTodoItemAsync(id);
            if (!result)
            {
                return await Task.FromResult(Result.Failure("Todo not found."));
            }
            return await Task.FromResult(Result.Success());
        }

        public async Task<Result<IEnumerable<TodoItemDto>>> GetAllTodosAsync()
        {
            var users = await todoRepository.GetTodoItemsAsync();
            return await Task.FromResult(Result.Success(users));
        }

        public async Task<Result<TodoItemDto>> GetTodoByIdAsync(Guid id)
        {
            var user = await todoRepository.GetTodoItemByIdAsync(id);
            if (user is null)
            {
                return await Task.FromResult(Result.Failure<TodoItemDto>("Todo not found."));
            }
            return await Task.FromResult(Result.Success(user));
        }

        public async Task<Result> UpdateTodoAsync(TodoItemDto todoDto)
        {
            var result = await todoRepository.UpdateTodoItemAsync(todoDto);
            if (result is null)
            {
                return await Task.FromResult(Result.Failure("Unable to update."));
            }
            return await Task.FromResult(Result.Success());
        }

        public async Task<Result<IEnumerable<TodoItemDto>>> GetAllTodosByOwnerAsync(Guid ownerId)
        {
            var users = await todoRepository.GetTodoItemsByOwnerAsync(ownerId);
            return await Task.FromResult(Result.Success(users));
        }
    }
}
