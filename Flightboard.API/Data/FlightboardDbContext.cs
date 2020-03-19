using System;
using Flightboard.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Flightboard.API.Data
{
    public class FlightboardDbContext : IdentityDbContext<User>
    {
        public FlightboardDbContext(DbContextOptions<FlightboardDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airline>().ToTable(typeof(Airline).Name);

            modelBuilder.Entity<Flight>().ToTable(typeof(Flight).Name)
                        .Property( f => f.DayOfWeek)
                        .HasConversion(
                            v => v.ToString(),
                            v => (DayOfWeek) Enum.Parse(typeof(DayOfWeek), v));

            modelBuilder.Entity<Schedule>().ToTable(typeof(Schedule).Name)
                        .Property(f => f.Status)
                        .HasConversion(
                            v => v.ToString(),
                            v => (Status) Enum.Parse(typeof(Status), v));
        }

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
