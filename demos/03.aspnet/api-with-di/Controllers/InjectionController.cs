using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class InjectionController : ControllerBase
{
    IGenerateMessage _generateMessage;

    public InjectionController(IGenerateMessage generateMessage)
    {
        _generateMessage = generateMessage;
    }
    [HttpGet(Name = "GetGoodbyeController")]
    public string Get(string name)
    {
        return _generateMessage.Generate(name);
    }
}
