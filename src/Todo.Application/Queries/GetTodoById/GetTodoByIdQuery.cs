using MediatR;
using Todo.Domain.Entities;

namespace Todo.Application.Queries.GetTodoById
{
    public record GetTodoByIdQuery(Guid Id) : IRequest<TodoItem?>;
}
