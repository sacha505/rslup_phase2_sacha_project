using Microsoft.AspNetCore.Mvc;

namespace rslup_phase2_sacha_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightConditionsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<FlightConditionsController> _logger;

        public FlightConditionsController(ILogger<FlightConditionsController> logger)
        {
            _logger = logger;
        }
        //incorportate the boiler plate because we'll probably need to know the weather before we fly

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<FlightCondition> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new FlightCondition
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}