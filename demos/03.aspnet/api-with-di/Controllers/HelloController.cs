using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    GreetMessage _greetMessage;

    public HelloController()
    {
        _greetMessage = new GreetMessage();
    }

    [HttpGet(Name = "HelloController")]
    public string Get(string name)
    {
        return _greetMessage.Generate(name);
    }
}
