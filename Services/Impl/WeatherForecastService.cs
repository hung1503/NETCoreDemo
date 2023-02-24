using NETCore.Models;

namespace NETCore.Services;

public class WeatherForecastService : IWeatherForecastService 
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecast> _logger;
    private int counter;

    public WeatherForecastService(ILogger<WeatherForecast> logger)
    {
        _logger = logger;
        _logger.LogInformation("WeatherForecastService constructor");
    }

    public IEnumerable<WeatherForecast> Forecast(int days)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}