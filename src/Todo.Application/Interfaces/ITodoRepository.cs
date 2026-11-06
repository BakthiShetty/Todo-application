using Todo.Domain.Entities;

namespace Todo.Application.Interfaces
{    
    public interface ITodoRepository
    
    {
        Task<TodoItem> AddAsync(TodoItem entity, CancellationToken cancellationToken = default);
        Task<TodoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(TodoItem entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}