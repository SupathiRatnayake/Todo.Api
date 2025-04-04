﻿using Todo.Core.DTOs;
using Todo.Core.Entities;

namespace Todo.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<UserDto> AddUserAsync(UserDto userDto);
        Task<UserDto?> UpdateUserAsync(UserDto userDto);
        Task<bool> DeletUserAsync(Guid id);

    }
}
