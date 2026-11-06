using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Persistence
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        // DbSet name must match what we used elsewhere (_db.Todos)
        public DbSet<TodoItem> Todos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>(b =>
            {
                b.HasKey(t => t.Id);
                b.Property(t => t.Title).IsRequired().HasMaxLength(200);
                b.Property(t => t.CreatedAt).IsRequired();
            });
        }
    }
}
