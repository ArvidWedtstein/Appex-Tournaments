using Microsoft.AspNetCore.Mvc;

namespace baggend.Controllers;

[ApiController]
[Route("[controller]")]
public class TournamentsController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TournamentsController> _logger;

    public TournamentsController(ILogger<TournamentsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Tournament> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Tournament
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
