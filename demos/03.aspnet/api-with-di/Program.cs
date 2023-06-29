
using api.Services;

namespace api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        //builder.Services.AddScoped<IGenerateMessage, GoodbyeMessage>();
        builder.Services.AddScoped<IGenerateMessage, GreetMessage>();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
