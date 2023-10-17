namespace RestaurantAPI;

public interface IWeatherForcastService
{
    IEnumerable<WeatherForecast> Get(int count, int min, int max);
}