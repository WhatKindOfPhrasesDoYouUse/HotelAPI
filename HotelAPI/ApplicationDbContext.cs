using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<HotelType> HotelTypes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PaymentRoom> PaymentRooms { get; set; }
        public DbSet<HotelReview> HotelReviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<RequestService> RequestServices { get; set; }
        public DbSet<RequestServiceReview> RequestServiceReviews { get; set; }
        public DbSet<Comfort> Comforts { get; set; }
        public DbSet<RoomComfort> RoomComforts { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<TravelReview> TravelReviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация Card

            modelBuilder.Entity<Card>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasIndex(c => c.Number)
                .IsUnique();

            // Конфигурация Role

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            // Конфигурация UserAccount

            modelBuilder.Entity<UserAccount>()
                .HasIndex(ua => ua.Email)
                .IsUnique();

            modelBuilder.Entity<UserAccount>()
                .HasIndex(ua => ua.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<UserAccount>()
                .HasIndex(ua => ua.Passport)
                .IsUnique();

            modelBuilder.Entity<UserAccount>()
                .HasOne(c => c.Card)
                .WithMany(ua => ua.UserAccounts)
                .HasForeignKey(k => k.CardId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация UserRole

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(ua => ua.Roles)
                .HasForeignKey(k => k.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserAccounts)
                .HasForeignKey(k => k.RoleId);

            // Конфигурация HotelType

            modelBuilder.Entity<HotelType>()
                .HasIndex(ht => ht.Name)
                .IsUnique();

            // Конфигурация Hotel

            modelBuilder.Entity<Hotel>()
                .HasIndex(h => h.Name)
                .IsUnique();

            modelBuilder.Entity<Hotel>()
                .HasIndex(h => h.Address)
                .IsUnique();

            modelBuilder.Entity<Hotel>()
                .HasIndex(h => h.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Hotel>()
                .HasIndex(h => h.Email)
                .IsUnique();

            modelBuilder.Entity<Hotel>()
                .HasOne(m => m.Manager)
                .WithMany(h => h.Hotels)
                .HasForeignKey(k => k.ManagerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hotel>()
                .HasOne(ht => ht.HotelType)
                .WithMany(h => h.Hotels)
                .HasForeignKey(k => k.HotelTypeId);

            // Конфигурация Room

            modelBuilder.Entity<Room>()
                .HasIndex(r => r.RoomNumber)
                .IsUnique();

            modelBuilder.Entity<Room>()
                .HasOne(h => h.Hotel)
                .WithMany(r => r.Rooms)
                .HasForeignKey(k => k.HotelId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Конфигурация Bookings

            modelBuilder.Entity<Booking>()
                .HasOne(ua => ua.UserAccount)
                .WithMany(b => b.Bookings)
                .HasForeignKey(k => k.UserAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(r => r.Room)
                .WithMany(b => b.Bookings)
                .HasForeignKey(k => k.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Конфигурация PaymentRoom

            modelBuilder.Entity<PaymentRoom>()
                .HasOne(b => b.Booking)
                .WithMany(pr => pr.PaymentRooms)
                .HasForeignKey(k => k.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация HotelReview

            modelBuilder.Entity<HotelReview>()
                .HasOne(h => h.Hotel)
                .WithMany(hr => hr.HotelReviews)
                .HasForeignKey(k => k.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HotelReview>()
                .HasOne(ua => ua.UserAccount)
                .WithMany(hr => hr.HotelReviews)
                .HasForeignKey(k => k.UserAccountId);

            // Конфигурация Service

            modelBuilder.Entity<Service>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<Service>()
                .HasOne(h => h.Hotel)
                .WithMany(s => s.Services)
                .HasForeignKey(k => k.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация Request Service

            modelBuilder.Entity<RequestService>()
                .HasOne(s => s.Service)
                .WithMany(rs => rs.RequestServices)
                .HasForeignKey(k => k.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RequestService>()
                .HasOne(ua => ua.UserAccount)
                .WithMany(rs => rs.RequestServices)
                .HasForeignKey(k => k.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация RequestServiceReview

            modelBuilder.Entity<RequestServiceReview>()
                .HasOne(rs => rs.RequestService)
                .WithMany(rsr => rsr.RequestServiceReviews)
                .HasForeignKey(k => k.RequestServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RequestServiceReview>()
                .HasOne(ua => ua.UserAccount)
                .WithMany(rsr => rsr.RequestServiceReviews)
                .HasForeignKey(k => k.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация Comfort

            modelBuilder.Entity<Comfort>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Конфигурация RoomComfort

            modelBuilder.Entity<RoomComfort>()
                .HasKey(rc => new { rc.RoomId, rc.ComfortId});

            modelBuilder.Entity<RoomComfort>()
                .HasOne(r => r.Room)
                .WithMany(c => c.Comforts)
                .HasForeignKey(k => k.RoomId);

            modelBuilder.Entity<RoomComfort>()
                .HasOne(c => c.Comfort)
                .WithMany(r => r.Rooms)
                .HasForeignKey(k => k.ComfortId);

            // Конфигурация Travel

            modelBuilder.Entity<Travel>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Travel>()
                .HasOne(h => h.Hotel)
                .WithMany(t => t.Travels)
                .HasForeignKey(k => k.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация TravelReview

            modelBuilder.Entity<TravelReview>()
                .HasOne(t => t.Travel)
                .WithMany(tr => tr.TravelReviews)
                .HasForeignKey(k => k.TravelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TravelReview>()
                .HasOne(ua => ua.UserAccount)
                .WithMany(tr => tr.TravelReviews)
                .HasForeignKey(k => k.TravelId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
