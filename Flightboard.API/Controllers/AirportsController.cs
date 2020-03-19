using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Models;
using Flightboard.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flightboard.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly AirportService _airportService;

        public AirportsController(AirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> Get(int id)
        {
            return await _airportService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Airport>>> GetAll()
        {
            return await _airportService.GetAllAsync(); ;
        }

        [HttpPost]
        public async Task<ActionResult<Airport>> Post([FromBody] AirportCreateRequest request)
        {
            var airport = new Airport
            {
                Name = request.Name,
                ShortName = request.ShortName
            };

            return await _airportService.CreateAsync(airport);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Airport>> Put(int id, [FromBody] AirportCreateRequest request)
        {
            var airport = new Airport
            {
                Id = id,
                Name = request.Name,
                ShortName = request.ShortName
            };

            return await _airportService.UpdateAsync(airport);
        }
    }
}
