using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Models;
using Flightboard.API.Requests;
using Flightboard.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flightboard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public SchedulesController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> Get(int id)
        {
            return await _scheduleService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetAll()
        {
            return await _scheduleService.GetAllAsync(); ;
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> Create([FromBody] ScheduleCreateRequest request)
        {
            var schedule = await _scheduleService.CreateAsync(new Schedule
            {
                ActualDepartureTime = request.ActualDepartureTime,
                EstimatedDepartureTime = request.EstimatedDepartureTime,
                FlightId = request.FlightId,
                Status = request.Status
            });

            return schedule;
        }
    }
}
