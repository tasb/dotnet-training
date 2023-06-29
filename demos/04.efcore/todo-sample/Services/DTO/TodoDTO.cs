namespace Tasb.DotnetTraining.TodoList.Services.DTO;

public class TodoDTO
{

    public TodoDTO()
    {

    }
    public TodoDTO(Todo todo)
    {
        this.Id = todo.Id;
        this.Name = todo.Name;
        this.IsComplete = todo.IsComplete;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    public Todo ToTodo() => new()
    {
        Id = this.Id,
        Name = this.Name,
        IsComplete = this.IsComplete
    };

    public void CopyTo(Todo todo)
    {
        todo.Name = this.Name;
        todo.IsComplete = this.IsComplete;
    }
}
