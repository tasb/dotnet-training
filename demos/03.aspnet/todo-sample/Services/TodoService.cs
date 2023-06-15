using Tasb.DotnetTraining.TodoList.Models;

namespace Tasb.DotnetTraining.TodoList.Services;

public class TodoService
{
    private readonly List<Todo> _todos = new()
    {
        new Todo { Id = 1, Name = "Learn C#", IsComplete = false },
        new Todo { Id = 2, Name = "Learn ASP.NET Core", IsComplete = false },
        new Todo { Id = 3, Name = "Learn EF Core", IsComplete = false },
        new Todo { Id = 4, Name = "Learn Unit Testing", IsComplete = false },
    };

    public Task<List<Todo>> GetTodosAsync() => Task.FromResult(_todos);

    public Task<Todo?> GetTodoAsync(int id) => Task.FromResult(_todos.FirstOrDefault(t => t.Id == id));

    public Task<Todo> AddTodoAsync(Todo todo)
    {
        todo.Id = _todos.Max(t => t.Id) + 1;
        _todos.Add(todo);
        return Task.FromResult(todo);
    }

    public Task<Todo?> UpdateTodoAsync(Todo todo)
    {
        var existingTodo = _todos.FirstOrDefault(t => t.Id == todo.Id);
        if (existingTodo is null)
        {
            return Task.FromResult<Todo?>(null);
        }

        existingTodo.Name = todo.Name;
        existingTodo.IsComplete = todo.IsComplete;
        return Task.FromResult<Todo?>(existingTodo);
    }

    public Task<bool> DeleteTodoAsync(int id)
    {
        var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo is null)
        {
            return Task.FromResult(false);
        }

        _todos.Remove(existingTodo);
        return Task.FromResult(true);
    }
}
