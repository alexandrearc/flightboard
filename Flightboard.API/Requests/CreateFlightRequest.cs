using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flightboard.API.Requests
{
    public class FlightCreateRequest
    {
        public string Number { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DayOfWeek DayOfWeek { get; set; }
        public string Destination { get; set; }
        public string ScheduledDepartureTime { get; set; }
    }
}