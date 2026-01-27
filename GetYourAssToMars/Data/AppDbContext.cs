using GetYourAssToMars.Models;
using Microsoft.EntityFrameworkCore;

namespace GetYourAssToMars.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Location> Locations => Set<Location>();
}