using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Models;

namespace Flightboard.API.Services
{
    public class FlightboardService
    {
        private readonly FlightService _flightService;
        private readonly ScheduleService _scheduleService;

        public FlightboardService(FlightService flightService, ScheduleService scheduleService)
        {
            _flightService = flightService;
            _scheduleService = scheduleService;
        }

        public async Task<List<FlightboardFlight>> GetFlightsByDateAsync(DateTime date)
        {
            var flightboardflights = new List<FlightboardFlight>();

            var flights = await _flightService.GetFlightsByDateAsync(date);

            foreach (var flight in flights)
            {
                var schedule = await _scheduleService.GetByFlightAndDate(flight.Id, date);

                flightboardflights.Add(Create(flight, schedule, date));
            }

            return flightboardflights;
        }

        public FlightboardFlight Create(Flight flight, Schedule schedule, DateTime date)
        {
            if(schedule == null)
            {
                return new FlightboardFlight
                {
                    Date = date,
                    ActualDepartureTime = flight.ScheduledDepartureTime,
                    EstimatedDepartureTime = flight.ScheduledDepartureTime,
                    ScheduledDepartureTime = flight.ScheduledDepartureTime,
                    Destination = flight.Destination,
                    Number = flight.Number,
                    FlightId = flight.Id,
                    Status = Status.OnTime
                };
            }

            return new FlightboardFlight
            {
                Date = date,
                ActualDepartureTime = schedule.ActualDepartureTime,
                EstimatedDepartureTime = schedule.EstimatedDepartureTime,
                ScheduledDepartureTime = flight.ScheduledDepartureTime,
                Destination = flight.Destination,
                Number = flight.Number,
                FlightId = flight.Id,
                Status = schedule.Status
            };
        }

    }
}