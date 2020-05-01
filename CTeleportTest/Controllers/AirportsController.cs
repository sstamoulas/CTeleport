using CTeleportTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CTeleportTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportsController(IAirportService service)
        {
            _airportService = service;
        }

        [HttpGet("source/{source}/target/{target}")]
        public IActionResult Get(string source, string target)
        {
            var distance = _airportService.GetByIATA(source, target);
            if (distance > 0)
                return Ok(distance);
            return NotFound("You have entered an invalid IATA code. Please check and revise accordingly.");
        }
    }
}
