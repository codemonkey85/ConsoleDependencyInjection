using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>().HasData(new[]
            {
                new TodoItem { Id = 1, Title = "Task 1", IsCompleted = false, },
                new TodoItem { Id = 2, Title = "Task 2", IsCompleted = false, },
                new TodoItem { Id = 3, Title = "Task 3", IsCompleted = true, },
                new TodoItem { Id = 4, Title = "Task 4", IsCompleted = false, },
                new TodoItem { Id = 5, Title = "Task 5", IsCompleted = false, },
            });
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
