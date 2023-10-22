using Microsoft.AspNetCore.Mvc;

namespace rslup_phase2_sacha_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaneTypeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Jumbo Passenger Jet", "Mid-Size Passenger Jet", "Light Passenger Jet", "Passenger Turboprop", "Cargo Airplane", "Private Jet", "Propeller Plane", "Amphibious"
    };

        private readonly ILogger<PlaneTypeController> _logger;

        public PlaneTypeController(ILogger<PlaneTypeController> logger)
        {
            _logger = logger;
        }
        //incorportate the boiler plate because we'll probably need to know the weather before we fly

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<PlaneType> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new PlaneType
            {
          
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}