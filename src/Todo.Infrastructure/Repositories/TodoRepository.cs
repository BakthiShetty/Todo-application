using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Persistence;
namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _db;

        public TodoRepository(TodoDbContext db)
        {
            _db = db;
        }

        public async Task<TodoItem> AddAsync(TodoItem entity, CancellationToken cancellationToken)
        {
            _db.Todos.Add(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<TodoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _db.Todos.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<TodoItem>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _db.Todos.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(TodoItem entity, CancellationToken cancellationToken)
        {
            _db.Todos.Update(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _db.Todos.FindAsync(id, cancellationToken);
            if (entity != null)
            {
                _db.Todos.Remove(entity);
                 await _db.SaveChangesAsync(cancellationToken);
            }
        }

    }
}
