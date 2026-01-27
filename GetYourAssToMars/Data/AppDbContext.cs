using GetYourAssToMars.Models;
using Microsoft.EntityFrameworkCore;

namespace GetYourAssToMars.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Location> Locations => Set<Location>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries<Location>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            entry.Entity.CalculateScore();
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}