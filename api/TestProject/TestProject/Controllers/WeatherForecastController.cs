using Microsoft.AspNetCore.Mvc;
using TestProject.Context;
using TestProject.Dtos;
using TestProject.Services;

namespace TestProject.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMyService _myService;

    public WeatherForecastController(IMyService myService)
    {
        _myService = myService;
    }

    
    
    [HttpPost(Name = "CreateUser")]
    public async Task<ActionResult<Guid>> CreateUser(UserDto userInfo, CancellationToken cancellationToken)
    {
        var result = await _myService.CreateUser(userInfo, cancellationToken);
        return Ok(result);
    }
}