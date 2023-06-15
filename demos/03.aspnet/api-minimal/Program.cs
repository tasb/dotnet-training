var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/hello/{name}", (string name) =>
{
    return Results.Text($"Hello, {name}!");
})
.Produces<string>(StatusCodes.Status200OK)
.WithName("GetHello")
.WithOpenApi()
.WithTags("HelloGroup");

app.MapGet("/goodbye", () => "Goodbye, World!")
.ExcludeFromDescription();

app.Run();
