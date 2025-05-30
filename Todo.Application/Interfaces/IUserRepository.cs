﻿using Todo.Application.DTOs;

namespace Todo.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<UserDto?> GetUserByEmailAsync(EmailRequestDto emailDto);
        Task<UserDto> AddOrUpDateUserAsync(UserDto userDto);
        Task<UserDto> AddUserAsync(UserDto userDto);
        Task<UserDto?> UpdateUserAsync(UserDto userDto);
        Task<bool> DeletUserAsync(Guid id);

    }
}
