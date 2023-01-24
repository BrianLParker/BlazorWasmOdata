using BlazorOdata.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BlazorOdata.Server.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class WeatherForecastsController : ControllerBase
    {

        private readonly ILogger<WeatherForecastsController> _logger;
        private readonly WeatherForecastService weatherForecastService;

        public WeatherForecastsController(ILogger<WeatherForecastsController> logger, WeatherForecastService weatherForecastService)
        {
            _logger = logger;
            this.weatherForecastService = weatherForecastService;
        }

        /// <summary>
        /// This simulates a call to a database query. This works well with EntityFramework as
        /// DbSet<T> returns a Queryable<T> it does not return the data until materialized
        /// it passes the query all the way to the database provider.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public IQueryable<WeatherForecast> Get() 
            => weatherForecastService.WeatherForecasts;
    }
}