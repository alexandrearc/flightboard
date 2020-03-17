using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Models;
using Flightboard.API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Flightboard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirlinesController : ControllerBase
    {
        private readonly AirlineService _airlineService;

        public AirlinesController(AirlineService airlineService)
        {
            _airlineService = airlineService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Airline>> Get(int id)
        {
            return await _airlineService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Airline>>> GetAll()
        {
            return await _airlineService.GetAllAsync(); ;
        }

        [HttpPost]
        public async Task<ActionResult<Airline>> Post([FromBody] AirlineCreateRequest request)
        {
            var airline = new Airline
            {
                Name = request.Name,
                ShortName = request.ShortName
            };

            return await _airlineService.CreateAsync(airline);
        }
    }
}
