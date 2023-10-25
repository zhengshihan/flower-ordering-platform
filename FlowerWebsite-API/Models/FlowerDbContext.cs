using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace FlowerWebsite_API.Models
{
    public class FlowerDbContext : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = "Server=localhost;Database=FlowerDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connStr);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
