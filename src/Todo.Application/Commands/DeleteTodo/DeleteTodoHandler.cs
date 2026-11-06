using MediatR;
using Todo.Application.Interfaces;

namespace Todo.Application.Commands.DeleteTodo
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand,Unit>
    {
        private readonly ITodoRepository _repository;

        public DeleteTodoHandler(ITodoRepository repository) => _repository = repository;

        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
