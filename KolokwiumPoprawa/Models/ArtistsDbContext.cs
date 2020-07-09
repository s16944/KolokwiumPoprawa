using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawa.Models
{
    public class MyDbContext : DbContext
    {
        protected MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}