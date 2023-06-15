using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    GreetMessage _greetMessage;
    ILogger<HelloController> _logger;

    public HelloController(ILogger<HelloController> logger)
    {
        _greetMessage = new GreetMessage();
        _logger = logger;
    }

    [HttpGet(Name = "HelloController")]
    public string Get(string name)
    {
        _logger.LogInformation("HelloController.Get() called. Name: {name}", name ?? "null");
        return _greetMessage.Generate(name!);
    }
}
