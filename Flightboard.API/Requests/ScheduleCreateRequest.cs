using System;
using Flightboard.API.Models;

namespace Flightboard.API.Requests
{
    public class ScheduleCreateRequest
    {
        public int FlightId { get; set; }
        public DateTime EstimatedDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public Status Status { get; set; }
    }
}