using NETCore.Models;

namespace NETCore.Services;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> Forecast(int days);
}