using BlazorOdata.Shared;

namespace BlazorOdata.Server;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherForecastService()
    {
        this.WeatherForecasts = Enumerable.Range(start: 1, count: 20000000).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddMinutes(index),
            TemperatureC = Random.Shared.Next(minValue: -20, maxValue: 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList()
        .AsQueryable();
    }

    public IQueryable<WeatherForecast> WeatherForecasts { get; }
}
