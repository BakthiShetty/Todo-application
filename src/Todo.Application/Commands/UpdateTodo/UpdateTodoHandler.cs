using MediatR;
using Todo.Application.Interfaces;

namespace Todo.Application.Commands.UpdateTodo
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, Unit>
    {
        private readonly ITodoRepository _repository;

        public UpdateTodoHandler(ITodoRepository repository) => _repository = repository;

        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (existing == null) throw new KeyNotFoundException($"Todo with id {request.Id} not found.");

            existing.Title = request.Title;
            existing.Description = request.Description;
            existing.IsCompleted = request.IsCompleted;

            await _repository.UpdateAsync(existing, cancellationToken);
            return Unit.Value;
        }
    }
}
