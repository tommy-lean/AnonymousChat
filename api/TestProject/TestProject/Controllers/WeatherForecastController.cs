using Microsoft.AspNetCore.Mvc;
using TestProject.Context;
using TestProject.Dtos;
using TestProject.Models;
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
    // -----
    [HttpGet(Name = "AuthenticationUser")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<ActionResult<Guid>> AuthenticationUser(UserDto userInfo, CancellationToken cancellationToken, User userServerInfo)
    {
        var result = await _myService.AuthenticationUser(userInfo, cancellationToken, userServerInfo);
        return Ok(result);
    }
    // -----
}