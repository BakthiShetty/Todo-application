namespace Todo.API.Contracts.Todo
{
    public class UpdateTodoRequest
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
