using Todo.Core.DTOs;

namespace Todo.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<UserDto> AddUserAsync(UserDto userDto);
        Task<UserDto?> UpdateUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
