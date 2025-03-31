using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;

namespace Todo.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsers();
        Task<UserEntity> GetUserByIdAsync(Guid id);
        Task<UserEntity> AddUserAsync(UserEntity entity);
        Task<UserEntity> UpdateUserAsync(Guid userId, UserEntity entity);
        Task<bool> DeletUserAsync(Guid id);

    }
}
