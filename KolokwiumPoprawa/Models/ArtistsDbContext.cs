using KolokwiumPoprawa.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawa.Models
{
    public class ArtistsDbContext : DbContext
    {
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ArtMovement> ArtMovements { get; set; }

        protected ArtistsDbContext()
        {
        }

        public ArtistsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PaintingConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ArtMovementConfiguration());
        }
    }
}