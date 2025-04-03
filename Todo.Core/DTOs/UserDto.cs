using Todo.Core.Entities;

namespace Todo.Core.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public static explicit operator UserDto(Task<UserEntity?> v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator UserDto(UserEntity v)
        {
            throw new NotImplementedException();
        }
    }
}
