using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace RestaurantAPI
{
    public class WeatherForcastService : IWeatherForcastService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
            public IEnumerable<WeatherForecast> Get(int count, int Min,int Max)
            {
                return Enumerable.Range(1, count).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(Min, Max),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
            }
    }
}
