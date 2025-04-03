namespace Todo.Core.DTOs
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public Guid OwnerId { get; set; }
    }
}
