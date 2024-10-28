using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories
{
    public class CardDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasIndex(s => s.Number)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
