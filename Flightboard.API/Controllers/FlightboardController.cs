using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Models;
using Flightboard.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flightboard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightboardController : ControllerBase
    {
        private readonly FlightboardService _flightboardService;

        public FlightboardController(FlightboardService flightboardService)
        {
            _flightboardService = flightboardService;
        }

        [HttpGet("date/{requestDate:datetime}")]
        public async Task<ActionResult<List<FlightboardFlight>>> GetFlightsByDate(DateTime requestDate)
        {
            var flightsResponse = await _flightboardService.GetFlightsByDateAsync(requestDate);

            return Ok(flightsResponse);
        }
    }
}
