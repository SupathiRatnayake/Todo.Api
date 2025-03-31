using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserEntity> AddUserAsync(UserEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Users.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<UserEntity> UpdateUserAsync(Guid userId, UserEntity entity)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is not null)
            {
                user.Name = entity.Name;
                user.Email = entity.Email;

                await dbContext.SaveChangesAsync();
                return user;
            }

            return entity;
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

    }
}
