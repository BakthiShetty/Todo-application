namespace Todo.API.Contracts.Todo
{
    public class CreateTodoRequest
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
