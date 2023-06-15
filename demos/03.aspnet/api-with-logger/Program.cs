
using api.Services;

namespace api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        builder.Services.AddControllers();
        builder.Services.AddScoped<IGenerateMessage, GoodbyeMessage>();

        var app = builder.Build();

        app.UseHttpLogging();
        app.MapControllers();

        app.Run();
    }
}
