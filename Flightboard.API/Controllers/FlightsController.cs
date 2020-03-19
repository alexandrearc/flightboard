using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class FlightsController : ControllerBase
    {
        private readonly FlightService _flightService;

        public FlightsController(FlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> Get(int id)
        {
            return await _flightService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Flight>>> GetAll()
        {
            return await _flightService.GetAllAsync(); ;
        }

        [HttpPost]
        public async Task<ActionResult<Flight>> Create([FromBody] FlightCreateRequest request)
        {
            var flight = await _flightService.CreateAsync(new Flight
            {
                Number = request.Number,
                DayOfWeek = request.DayOfWeek,
                Destination = request.Destination,
                ScheduledDepartureTime = DateTime.ParseExact(request.ScheduledDepartureTime, "HH:mm:ss", CultureInfo.InvariantCulture)
            }); 

            return flight;
        }


    }
}
