using System.Collections.Generic;
using System.Threading.Tasks;
using Flightboard.API.Data;
using Flightboard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flightboard.API.Services
{
    public class ScheduleService
    {
        private readonly FlightboardDbContext _db;

        public ScheduleService(FlightboardDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Schedule> CreateAsync(Schedule schedule)
        {
            await _db.Schedules.AddAsync(schedule);
            await _db.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> GetByIdAsync(int id)
        {
            return await _db.Schedules.FindAsync(id);
        }

        public async Task<List<Schedule>> GetAllAsync()
        {
            return await _db.Schedules.ToListAsync();
        }
    }
}
