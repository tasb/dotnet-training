

namespace Tasb.DotnetTraining.TodoList.Services;

public class TodoService
{
    private readonly TodoDbContext _context;
    private readonly ILogger<TodoService> _logger;
    public TodoService(TodoDbContext context, ILogger<TodoService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<TodoDTO> CreateTodoAsync(TodoDTO newTodo)
    {
        var todo = newTodo.ToTodo();
        _ = _context.Todos.Add(todo);
        try
        {
            _ = await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Exception adding Todo {newTodo.Id}, {newTodo.Name}");
            throw;
        }

        var returnValue = new TodoDTO(todo);
        return returnValue;
    }

    public async Task<TodoDTO> DeleteTodoAsync(int id)
    {
        Todo? todo = await _context.Todos.FindAsync(id);
        if (todo is not Todo)
        {
            throw new ItemNotFoundException($"Todo not found with id {id}");
        }

        _context.Todos.Remove(todo);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Exception removing Todo {todo.Name}");
            throw;
        }

        TodoDTO returnValue = new TodoDTO(todo);
        return returnValue;
    }

    public async Task<TodoDTO> GetTodoAsync(int id)
    {
        Todo? todo = await _context.Todos.FindAsync(id);
        if (todo is not Todo)
        {
            throw new ItemNotFoundException($"Todo not found with id {id}");
        }

        TodoDTO returnValue = new TodoDTO(todo);
        return returnValue;
    }

    public async Task<IEnumerable<TodoDTO>> GetTodosAsync()
    {
        List<Todo> allTodos = await _context.Todos.OrderBy(acc => acc.Id).ToListAsync();
        IEnumerable<TodoDTO> returnList = allTodos.Select(t => new TodoDTO(t));
        return returnList;
    }

    public async Task<TodoDTO> UpdateTodoAsync(TodoDTO todo)
    {
        Todo? fromDB = await _context.Todos.FindAsync(todo.Id);

        if (fromDB is not Todo)
        {
            throw new ItemNotFoundException($"Todo not found with id {todo.Id}");
        }

        todo.CopyTo(fromDB);
        _context.Entry(fromDB).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Exception saving changes to Todo {todo.Id}, {todo.Name}");
            throw;
        }

        TodoDTO returnValue = new TodoDTO(fromDB);
        return returnValue;
    }
}
