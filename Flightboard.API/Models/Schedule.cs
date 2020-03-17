using System;

namespace Flightboard.API.Models
{
    public class Schedule
    {
        public Schedule()
        {
        }

        public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime EstimatedDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public Status Status { get; set; }
    }
}
