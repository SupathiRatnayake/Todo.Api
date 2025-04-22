using Microsoft.EntityFrameworkCore;
using Todo.Core.DTOs;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await dbContext.Users.Select(u => new UserDto
            {
                Id = u.Id, 
                Name = u.Name,
                Email = u.Email
            })
                .ToListAsync();
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var userEntity = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userEntity is null)
            {
                return null;
            }
            return new UserDto
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email
            };
        }
        public async Task<UserDto?> GetUserByEmailAsync(EmailRequestDto emailDto)
        {
            var userEntity = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == emailDto.Email);
            if (userEntity is null)
            {
                return null;
            }
            return new UserDto
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email
            };
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto)
        {
            UserEntity entity =
                new UserEntity
                {
                    Name = userDto.Name,
                    Email = userDto.Email, // Email should be unique. how to handle duplicate emails?
                };
            
            dbContext.Users.Add(entity);

            await dbContext.SaveChangesAsync(); // How to handle if database commit is unsuccessful?

            return new UserDto 
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
            };
        }

        public async Task<UserDto?> UpdateUserAsync(UserDto userDto)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userDto.Id);
            if (user is not null)
            {
                user.Name = userDto.Name;
                user.Email = userDto.Email;

                await dbContext.SaveChangesAsync();
                return userDto;
            }

            return null;
        }

        public async Task<bool> DeletUserAsync(Guid id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is not null)
            {
                dbContext.Users.Remove(user);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<UserDto> AddOrUpDateUserAsync(UserDto userDto)
        {
            if (userDto.Id != Guid.Empty)
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userDto.Id);
                if (user is not null)
                {
                    user.Name = userDto.Name;
                    user.Email = userDto.Email;

                    await dbContext.SaveChangesAsync();
                    return userDto;
                }
            }
            UserEntity entity =
                new UserEntity
                {
                    Name = userDto.Name,
                    Email = userDto.Email, // Email should be unique. how to handle duplicate emails?
                };

            dbContext.Users.Add(entity);

            await dbContext.SaveChangesAsync(); // How to handle if database commit is unsuccessful?

            return new UserDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
            };
        }
    }
}
