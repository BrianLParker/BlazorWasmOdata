using System.Text.Json.Serialization;

namespace BlazorOdata.Shared
{
    public class WeatherForecast
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTimeOffset Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        [JsonIgnore]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}