using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForcastService _services;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForcastService service)
        {
            _logger = logger;
            _services = service;
        }

        [HttpPost("/generate")]

        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count,
            [FromBody] TemperatureRequest request)
        {
            if (count < 0 || request.Max < request.Min)
            {
                return BadRequest();
            }

            var result = _services.Get(count, request.Min, request.Max);
            return Ok(result);
        }

    }
}