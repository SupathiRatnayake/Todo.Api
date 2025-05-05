using Todo.Application.DTOs;
using Todo.Application.Interfaces;
using Todo.Application.Shared;

namespace Todo.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<Result<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var users =  await userRepository.GetUsers();
            return await Task.FromResult(Result.Success(users));
        }

        public async Task<Result<UserDto>> GetUserByIdAsync(Guid id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            if (user is null)
            {
                return await Task.FromResult(Result.Failure<UserDto>("User not found."));
            }
            return await Task.FromResult(Result.Success(user));
        }
        public async Task<Result<UserDto>> GetUserByEmailAsync(EmailRequestDto emailDto)
        {
            var user = await userRepository.GetUserByEmailAsync(emailDto);
            if (user is null)
            {
                return await Task.FromResult(Result.Failure<UserDto>("User not found."));
            }
            return await Task.FromResult(Result.Success(user));
        }

        public async Task<Result<UserDto>> AddUserAsync(UserDto userDto) 
        {
            var result = await userRepository.AddUserAsync(userDto);
            if (result is null)
            {
                return await Task.FromResult(Result.Failure<UserDto>("Unable to create user."));
            }
            return await Task.FromResult(Result.Success(result));
        }

        public async Task<Result> UpdateUserAsync(UserDto userDto)
        {
            var result = await userRepository.UpdateUserAsync(userDto);
            if(result is null)
            {
                return await Task.FromResult(Result.Failure("Unable to update."));
            }
            return await Task.FromResult(Result.Success());
        }

        public async Task<Result> DeleteUserAsync(Guid id)
        {
            var result = await userRepository.DeletUserAsync(id);
            if (!result)
            {
                return await Task.FromResult(Result.Failure("User not found."));
            }
            return await Task.FromResult(Result.Success());
        }

        public async Task<Result<UserDto>> AddorUpdateUserAsync(UserDto userDto)
        {
            var result = await userRepository.AddOrUpDateUserAsync(userDto);
            if (result is null)
            {
                return await Task.FromResult(Result.Failure<UserDto>("Unable to create or update user."));
            }
            return await Task.FromResult(Result.Success(result));
        }
    }
}
