using Microsoft.AspNetCore.Mvc;
using NewComputerShop.Data;

namespace NewComputerShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepository repository;
        public WeatherForecastController(IRepository repository)
        {
            this.repository = repository;
           
        }


        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

       

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var categories = repository.Categories.ToList();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}