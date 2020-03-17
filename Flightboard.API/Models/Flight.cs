using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flightboard.API.Models
{
    public class Flight
    {
        public Flight()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Destination { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DaysOfWeek DayOfWeek { get; set; }
    }
}
