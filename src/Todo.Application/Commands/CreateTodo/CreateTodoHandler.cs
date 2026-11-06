using MediatR;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Commands.CreateTodo
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Guid>
    {
        private readonly ITodoRepository _repository;

        public CreateTodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            TodoItem todo = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };
    
        var added = await _repository.AddAsync(todo, cancellationToken);
            return added.Id;
        }

    }
}
