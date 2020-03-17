using System.Collections.Generic;
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

        public async Task<Flight> GetByIdAsync(int id)
        {
            return await _db.Flights.FindAsync(id);
        }

        public async Task<List<Flight>> GetAllAsync()
        {
            return await _db.Flights.ToListAsync();
        }
    }
}
