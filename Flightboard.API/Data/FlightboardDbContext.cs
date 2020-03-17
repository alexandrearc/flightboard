using System;
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
            modelBuilder.Entity<Airline>().ToTable(typeof(Airline).Name);

            modelBuilder.Entity<Flight>().ToTable(typeof(Flight).Name)
                        .Property( f => f.DayOfWeek)
                        .HasConversion(
                            v => v.ToString(),
                            v => (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), v));

        }


        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
