
namespace Tasb.DotnetTraining.TodoList.Models;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
    public DbSet<Commnent> Comments => Set<Commnent>();
}
