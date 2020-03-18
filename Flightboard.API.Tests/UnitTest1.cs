using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flightboard.API.Data;
using Flightboard.API.Models;
using Flightboard.API.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Flightboard.API.Tests
{
    public class FlightServiceTests
    {
        [Fact]
        public async Task GetFlightsByDateAsync_GivenHasFlightsOnWednesday_ShouldReturnFlights()
        {
            //Arrange
            var db = new FlightboardDbContext(CreateDbOptions("1")); //TODO: Should this just be a random Guid? 
            var flightService = CreateFlightService(db);

            var wednesdayFlight = new Flight { DayOfWeek = DayOfWeek.Wednesday, Destination = "Brazil", Number = "ANZ3002", ScheduledDepartureTime = new DateTime(1900, 01, 01, 12, 0, 0) };
            var fridayFlight = new Flight { DayOfWeek = DayOfWeek.Friday, Destination = "Brazil", Number = "ANZ3002", ScheduledDepartureTime = new DateTime(1900, 01, 01, 12, 0, 0) };

            db.Flights.AddRange(new List<Flight> { wednesdayFlight, fridayFlight });
            await db.SaveChangesAsync();

            //Act
            var flights = await flightService.GetFlightsByDateAsync(new DateTime(2020, 03, 18)); //This is a Wednesday

            //Assert
            Assert.False(flights.Any(f => f.DayOfWeek != DayOfWeek.Wednesday));
        }

        [Fact]
        public async Task GetFlightsByDateAsync_GivenHaventFlightsOnWednesday_ShouldNotReturnFlights()
        {
            //Arrange
            var db = new FlightboardDbContext(CreateDbOptions("2"));
            var flightService = CreateFlightService(db);

            var thursdayFlight = new Flight { DayOfWeek = DayOfWeek.Thursday, Destination = "Brazil", Number = "ANZ3002", ScheduledDepartureTime = new DateTime(1900, 01, 01, 12, 0, 0) };
            var fridayFlight = new Flight { DayOfWeek = DayOfWeek.Friday, Destination = "Brazil", Number = "ANZ3002", ScheduledDepartureTime = new DateTime(1900, 01, 01, 12, 0, 0) };

            db.Flights.AddRange(new List<Flight> { thursdayFlight, fridayFlight });
            await db.SaveChangesAsync();

            //Act
            var flights = await flightService.GetFlightsByDateAsync(new DateTime(2020, 03, 18)); //This is a Wednesday

            //Assert
            Assert.True(flights.Count() == 0);
        }

        private DbContextOptions<FlightboardDbContext> CreateDbOptions(string databaseName) {
            return new DbContextOptionsBuilder<FlightboardDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName).Options;
        }

        private FlightService CreateFlightService(FlightboardDbContext db)
        {
            return new FlightService(db);
        }
    }
}
