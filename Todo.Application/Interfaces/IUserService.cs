using Todo.Application.DTOs;
using Todo.Application.Shared;

namespace Todo.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task<Result<UserDto>> GetUserByIdAsync(Guid id);
        Task<Result<UserDto>> AddUserAsync(UserDto userDto);
        Task<Result<UserDto>> AddorUpdateUserAsync(UserDto userDto);
        Task<Result> UpdateUserAsync(UserDto userDto);
        Task<Result> DeleteUserAsync(Guid id);
        Task<Result<UserDto>> GetUserByEmailAsync(EmailRequestDto emailDto);
    }
}
