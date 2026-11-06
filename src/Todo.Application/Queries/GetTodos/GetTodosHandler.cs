using MediatR;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Queries.GetTodos
{
    public class GetTodosHandler : IRequestHandler<GetTodosQuery, List<TodoItem>>
    {
        private readonly ITodoRepository _repository;

        public GetTodosHandler(ITodoRepository repository) => _repository = repository;

        public async Task<List<TodoItem>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
