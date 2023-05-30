using Microsoft.Extensions.Configuration;

var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

string? logLevel = config.GetValue<string>("Logging:LogLevel:Default");
string? theKey = config.GetValue<string>("MyTwoLevelKey:TheKey");
int myKey = config.GetValue<int>("myKey");

Console.WriteLine($"LogLevel: {logLevel}");
Console.WriteLine($"TheKey: {theKey}");
Console.WriteLine($"myKey: {myKey}");

