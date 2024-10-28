using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories
{
    public class RoleDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public RoleDbContext(DbContextOptions<RoleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
