using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Interfaces;
using Todo.Core.DTOs;
using Todo.Core.Interfaces;

namespace Todo.Application.Services
{
    public class TodoService(ITodoItemRepository todoRepository) : ITodoService
    {
        public async Task<TodoItemDto> AddTodoAsync(TodoItemDto todoDto)
        {
            return await todoRepository.AddTodoItemAsync(todoDto);
        }

        public async Task<bool> DeleteTodoAsync(Guid id)
        {
            return await todoRepository.DeleteTodoItemAsync(id);
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllTodosAsync()
        {
            return await todoRepository.GetTodoItemsAsync();
        }

        public async Task<TodoItemDto?> GetTodoByIdAsync(Guid id)
        {
            return await todoRepository.GetTodoItemByIdAsync(id);
        }

        public async Task<TodoItemDto?> UpdateTodoAsync(TodoItemDto todoDto)
        {
            return await todoRepository.UpdateTodoItemAsync(todoDto);
        }
    }
}
