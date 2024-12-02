using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data
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
        public DbSet<Serv> Services { get; set; }
        public DbSet<RequestServ> RequestServices { get; set; }
        public DbSet<RequestServReview> RequestServiceReviews { get; set; }
        public DbSet<Comfort> Comforts { get; set; }
        public DbSet<PaymentTravel> PaymentTravels { get; set; }
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

            // Один к одному
            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasOne(ua => ua.Card)  
                    .WithOne(c => c.UserAccount)  
                    .HasForeignKey<UserAccount>(ua => ua.CardId) 
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Конфигурация Role

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

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
                .HasOne(h => h.Hotel)
                .WithMany(r => r.Rooms)
                .HasForeignKey(k => k.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

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
                .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity<Serv>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<Serv>()
                .HasOne(h => h.Hotel)
                .WithMany(s => s.Services)
                .HasForeignKey(k => k.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация Request Service

            modelBuilder.Entity<RequestServ>()
                .HasOne(s => s.Service)
                .WithMany(rs => rs.RequestServices)
                .HasForeignKey(k => k.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RequestServ>()
                .HasOne(ua => ua.UserAccount)
                .WithMany(rs => rs.RequestServices)
                .HasForeignKey(k => k.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация Comfort

            modelBuilder.Entity<Comfort>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Конфигурация RequestServReview

            modelBuilder.Entity<RequestServReview>()
                .HasOne(rs => rs.RequestServ)
                .WithMany(rsr => rsr.RequestServiceReviews)
                .HasForeignKey(k => k.RequestServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RequestServReview>()
                .HasOne(ua => ua.UserAccount)
                .WithMany(rsr => rsr.RequestServiceReviews)
                .HasForeignKey(k => k.UserAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация Travel

            modelBuilder.Entity<Travel>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Travel>()
                .HasOne(h => h.Hotel)
                .WithMany(t => t.Travels)
                .HasForeignKey(k => k.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация PaymentTravel

            modelBuilder.Entity<PaymentTravel>()
                .HasOne(t => t.UserAccount)
                .WithMany(pt => pt.PaymentTravels)
                .HasForeignKey(fk => fk.TravelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PaymentTravel>()
                .HasOne(t => t.Travel)
                .WithMany(pt => pt.PaymentTravels)
                .HasForeignKey(fk => fk.TravelId)
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

            // Конфигурация RoomComfort

            modelBuilder.Entity<RoomComfort>()
                .HasKey(rc => new { rc.RoomId, rc.ComfortId });

            modelBuilder.Entity<RoomComfort>()
                .HasOne(r => r.Room)
                .WithMany(c => c.Comforts)
                .HasForeignKey(k => k.RoomId);

            modelBuilder.Entity<RoomComfort>()
                .HasOne(c => c.Comfort)
                .WithMany(r => r.Rooms)
                .HasForeignKey(k => k.ComfortId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
