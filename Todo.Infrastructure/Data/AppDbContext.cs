using Microsoft.EntityFrameworkCore;
using Todo.Core.Entities;

namespace Todo.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TodoItemEntity> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItemEntity>()
                .HasOne(t => t.Owner)
                .WithMany(u => u.TodoItems)
                .HasForeignKey(t => t.OwnerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
