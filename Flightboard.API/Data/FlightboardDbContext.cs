using Flightboard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flightboard.API.Data
{
    public class FlightboardDbContext : DbContext
    {
        public FlightboardDbContext(DbContextOptions<FlightboardDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().ToTable(typeof(Flight).Name);
        }


        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
