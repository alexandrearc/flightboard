using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Data;
using Flightboard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flightboard.API.Services
{
    public class AirlineService
    {
        private readonly FlightboardDbContext _db;

        public AirlineService(FlightboardDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Airline> CreateAsync(Airline airline)
        {
            await _db.Airlines.AddAsync(airline);
            await _db.SaveChangesAsync();
            return airline;
        }

        public async Task<Airline> UpdateAsync(Airline airline)
        {
            _db.Airlines.Attach(airline).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return airline;
        }

        public async Task<Airline> GetByIdAsync(int id)
        {
            return await _db.Airlines.FindAsync(id);
        }

        public async Task<List<Airline>> GetAllAsync()
        {
            return await _db.Airlines.ToListAsync();
        }
    }
}
