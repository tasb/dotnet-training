
namespace api.Services;

public class GreetMessage : IGenerateMessage
{
    public string Generate(string name) => $"Hello {name ?? "World"}";
}
