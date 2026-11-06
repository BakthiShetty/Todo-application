using MediatR;

namespace Todo.Application.Commands.DeleteTodo
{
    public record DeleteTodoCommand(Guid Id) : IRequest<Unit>;
}
