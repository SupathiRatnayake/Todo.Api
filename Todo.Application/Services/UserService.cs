using Todo.Application.Interfaces;
using Todo.Core.DTOs;
using Todo.Core.Interfaces;

namespace Todo.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await userRepository.GetUsers();
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            return await userRepository.GetUserByIdAsync(id);
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto) 
        {
            return await userRepository.AddUserAsync(userDto);
        }

        public async Task<UserDto?> UpdateUserAsync(UserDto userDto)
        {
            return await userRepository.UpdateUserAsync(userDto);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await userRepository.DeletUserAsync(id);
        }
    }
}
