using MediatR;

namespace Todo.Application.Commands.UpdateTodo
{
    public record UpdateTodoCommand(Guid Id, string Title, string? Description, bool IsCompleted) : IRequest<Unit>;
}
