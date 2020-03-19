using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Data;
using Flightboard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flightboard.API.Services
{
    public class AirportService
    {
        private readonly FlightboardDbContext _db;

        public AirportService(FlightboardDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Airport> CreateAsync(Airport airport)
        {
            await _db.Airports.AddAsync(airport);
            await _db.SaveChangesAsync();
            return airport;
        }

        public async Task<Airport> UpdateAsync(Airport airport)
        {
            _db.Airports.Attach(airport).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return airport;
        }

        public async Task<Airport> GetByIdAsync(int id)
        {
            return await _db.Airports.FindAsync(id);
        }

        public async Task<List<Airport>> GetAllAsync()
        {
            return await _db.Airports.ToListAsync();
        }
    }
}
