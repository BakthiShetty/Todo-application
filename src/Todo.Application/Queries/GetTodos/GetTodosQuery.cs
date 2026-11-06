using MediatR;
using Todo.Domain.Entities;

namespace Todo.Application.Queries.GetTodos
{
    public record GetTodosQuery() : IRequest<List<TodoItem>>;
}
