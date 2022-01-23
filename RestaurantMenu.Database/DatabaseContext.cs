using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Database.Models;

namespace RestaurantMenu.Database
{
    /// <summary>
    ///     Database context
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // Auto migrate database
            if (!Database.IsInMemory())
            {
                Database.Migrate();
            }

            // Disable tracking entries
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Dishe> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
