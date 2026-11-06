using MediatR;

namespace Todo.Application.Commands.CreateTodo
{
    // Command (immutable) that asks the handler to create a Todo and return its Guid
    public record CreateTodoCommand(string Title, string? Description) : IRequest<Guid>;

}
