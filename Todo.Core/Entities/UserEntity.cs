namespace Todo.Core.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<TodoItemEntity> TodoItems { get; set; } = null!; // Navigation property to TodoItems
    }
}
