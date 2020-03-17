﻿using System;
using Flightboard.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flightboard.API.Requests
{
    public class FlightCreateRequest
    {
        public string Number { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DaysOfWeek DayOfWeek { get; set; }
        public string Destination { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
    }
}