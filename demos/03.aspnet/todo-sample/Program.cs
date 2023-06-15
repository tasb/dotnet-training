using Microsoft.AspNetCore.Mvc;
using Tasb.DotnetTraining.TodoList.Models;
using Tasb.DotnetTraining.TodoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

var todoEndpoints = app.MapGroup("/todo");

todoEndpoints.MapGet("/", async (TodoService todoService) =>
    await todoService.GetTodosAsync())
.Produces<List<Todo>>(StatusCodes.Status200OK)
.WithOpenApi();

todoEndpoints.MapGet("/{id}", async (int id, TodoService todoService) =>
    await todoService.GetTodoAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound())
.Produces<Todo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

todoEndpoints.MapPost("/", async ([FromBody]Todo todo, TodoService todoService) =>
{
    await todoService.AddTodoAsync(todo);
    return Results.Created($"/todo/{todo.Id}", todo);
})
.Produces<Todo>(StatusCodes.Status201Created)
.WithOpenApi();

todoEndpoints.MapPut("/{id}", async ([FromRoute]int id, [FromBody]Todo inputTodo, TodoService todoService) =>
{
    var todo = await todoService.GetTodoAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await todoService.UpdateTodoAsync(todo);

    return Results.NoContent();
})
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

todoEndpoints.MapDelete("/{id}", async (int id, TodoService todoService) =>
{
    if (await todoService.GetTodoAsync(id) is Todo todo)
    {
        await todoService.DeleteTodoAsync(id);
        return Results.Ok(todo);
    }

    return Results.NotFound();
})
.Produces<Todo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.Run();

