using Microsoft.EntityFrameworkCore;
using FitnessTracker.Api.Models;

namespace FitnessTracker.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Workout> Workouts => Set<Workout>();
}
