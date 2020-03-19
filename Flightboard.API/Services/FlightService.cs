using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flightboard.API.Data;
using Flightboard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flightboard.API.Services
{
    public class FlightService
    {
        private readonly FlightboardDbContext _db;

        public FlightService(FlightboardDbContext dbcontext)
        {
            _db = dbcontext;
        }

        public async Task<Flight> CreateAsync(Flight flight)
        {
            await _db.Flights.AddAsync(flight);
            await _db.SaveChangesAsync();
            return flight;
        }

        public async Task<Flight> UpdateAsync(Flight flight)
        {
            _db.Flights.Attach(flight).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return flight;
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            return await _db.Flights.FindAsync(id);
        }

        public async Task<List<Flight>> GetAllAsync()
        {
            return await _db.Flights.ToListAsync();
        }

        public async Task<List<Flight>> GetFlightsByDateAsync(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;
            return await _db.Flights.Where(f => f.DayOfWeek == dayOfWeek).ToListAsync();
        }
    }
}
