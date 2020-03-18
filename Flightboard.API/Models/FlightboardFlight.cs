using System;
namespace Flightboard.API.Models
{
    public class FlightboardFlight
    {
        public FlightboardFlight()
        {
        }

        public int FlightId { get; set; }
        public string Number { get; set; }
        public string Destination { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime EstimatedDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
    }
}
