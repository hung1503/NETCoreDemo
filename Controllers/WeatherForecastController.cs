using Microsoft.AspNetCore.Mvc;
using NETCore.Services;
using NETCore.Models;

namespace NETCore.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _service;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
    {
        _logger = logger;
        _service = service;
        _logger.LogInformation("This is the constructor");
        _logger.LogError("This is an error");
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _service.Forecast(3);
    }

    [HttpGet("{numDays}")]
    public IEnumerable<WeatherForecast> Get([FromRoute(Name ="numDays")]int days)
    {
        return _service.Forecast(days);
    }
}
