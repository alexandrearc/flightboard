using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Models;
using Flightboard.API.Requests;
using Flightboard.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flightboard.API.Controllers
{
    [Authorize]
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Airline>> Put(int id, [FromBody] AirlineCreateRequest request)
        {
            var airline = new Airline
            {
                Id = id,
                Name = request.Name,
                ShortName = request.ShortName
            };

            return await _airlineService.UpdateAsync(airline);
        }
    }
}
