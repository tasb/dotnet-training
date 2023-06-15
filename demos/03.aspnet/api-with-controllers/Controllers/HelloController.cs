using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet(Name = "GetHello")]
    public string Get(string name)
    {
        return $"Hello {name}";
    }
}
