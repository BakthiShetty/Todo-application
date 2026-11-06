using MediatR;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Queries.GetTodoById
{
    public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, TodoItem?>
    {
        private readonly ITodoRepository _repository;

        public GetTodoByIdHandler(ITodoRepository repository) => _repository = repository;

        public async Task<TodoItem?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
