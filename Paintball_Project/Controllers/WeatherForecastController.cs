using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.Interfaces.Services;

namespace Paintball_Project.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ISchedulingService _schedulingService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ISchedulingService schedulingService)
    {
        _logger = logger;
        _schedulingService = schedulingService;
    }

    [HttpGet("GetAll")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpPost("insert")]
    public async Task<IActionResult> Post([FromBody] SchedulingInsertRequest model)
    {
        var result = await _schedulingService.InsertAsync(model);

        if (result == 0)
            return BadRequest();

        return Ok(result);
        
    }
}
