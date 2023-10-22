using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace rslup_phase2_sacha_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightPathController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "France, Italy, Egypt, Germany, Wales, Ireland, China, Japan, India, America"
    };

        private readonly ILogger<FlightPathController> _logger;

        public FlightPathController(ILogger<FlightPathController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFlightPath")]

        public IEnumerable<FlightPath> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new FlightPath
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

}