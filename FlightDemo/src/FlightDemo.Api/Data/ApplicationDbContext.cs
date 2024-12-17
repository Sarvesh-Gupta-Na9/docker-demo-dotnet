using Microsoft.EntityFrameworkCore;
using FlightDemo.Api.Models;

namespace FlightDemo.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<FlightSchedule> FlightSchedules { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FlightSchedule>()
            .HasKey(f => f.FlightId);
    }
}
