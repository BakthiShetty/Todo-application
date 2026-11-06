using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Commands.CreateTodo;
using Todo.Application.Queries.GetTodos;
using Todo.Application.Queries.GetTodoById;
using Todo.Application.Commands.UpdateTodo;
using Todo.Application.Commands.DeleteTodo;
using Todo.API.Contracts.Todo;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequest req, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateTodoCommand(req.Title, req.Description), cancellationToken);
            return Created($"/api/todos/{id}", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetTodosQuery(), cancellationToken);
            var dto = items.Select(t => new TodoResponse
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt
            }).ToList();
            return Ok(dto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(new GetTodoByIdQuery(id), cancellationToken);
            if (item == null) return NotFound();
            var dto = new TodoResponse
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                CreatedAt = item.CreatedAt
            };
            return Ok(dto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoRequest req, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateTodoCommand(id, req.Title, req.Description, req.IsCompleted), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTodoCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
