using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Models;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Comfort> Comforts { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelReview> HotelReviews { get; set; }

    public virtual DbSet<HotelType> HotelTypes { get; set; }

    public virtual DbSet<PaymentRoom> PaymentRooms { get; set; }

    public virtual DbSet<PaymentTravel> PaymentTravels { get; set; }

    public virtual DbSet<RequestService> RequestServices { get; set; }

    public virtual DbSet<RequestServiceReview> RequestServiceReviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomComfort> RoomComforts { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

    public virtual DbSet<TravelReview> TravelReviews { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=hotel_db;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("booking_pkey");

            entity.ToTable("booking", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualPrice).HasColumnName("actual_price");
            entity.Property(e => e.CheckIn).HasColumnName("check_in");
            entity.Property(e => e.CheckOut).HasColumnName("check_out");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("booking_room_id_fkey");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("booking_user_account_id_fkey");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_pkey");

            entity.ToTable("card", "core");

            entity.HasIndex(e => e.Number, "card_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(5)
                .HasColumnName("date");
            entity.Property(e => e.Number)
                .HasMaxLength(16)
                .HasColumnName("number");
        });

        modelBuilder.Entity<Comfort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comfort_pkey");

            entity.ToTable("comfort", "core");

            entity.HasIndex(e => e.Name, "comfort_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hotel_pkey");

            entity.ToTable("hotel", "core");

            entity.HasIndex(e => e.Email, "hotel_email_key").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "hotel_phone_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConstructionYear).HasColumnName("construction_year");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.HotelTypeId).HasColumnName("hotel_type_id");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("phone_number");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.HotelType).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.HotelTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hotel_hotel_type_id_fkey");

            entity.HasOne(d => d.Manager).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("hotel_manager_id_fkey");
        });

        modelBuilder.Entity<HotelReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hotel_review_pkey");

            entity.ToTable("hotel_review", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.PublishDate).HasColumnName("publish_date");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelReviews)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("hotel_review_hotel_id_fkey");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.HotelReviews)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hotel_review_user_account_id_fkey");
        });

        modelBuilder.Entity<HotelType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hotel_type_pkey");

            entity.ToTable("hotel_type", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<PaymentRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_room_pkey");

            entity.ToTable("payment_room", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(30)
                .HasColumnName("payment_status");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Booking).WithMany(p => p.PaymentRooms)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("payment_room_booking_id_fkey");
        });

        modelBuilder.Entity<PaymentTravel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_travel_pkey");

            entity.ToTable("payment_travel", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(30)
                .HasColumnName("payment_status");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TravelId).HasColumnName("travel_id");
            entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

            entity.HasOne(d => d.Travel).WithMany(p => p.PaymentTravels)
                .HasForeignKey(d => d.TravelId)
                .HasConstraintName("payment_travel_travel_id_fkey");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.PaymentTravels)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("payment_travel_user_account_id_fkey");
        });

        modelBuilder.Entity<RequestService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_service_pkey");

            entity.ToTable("request_service", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalNotes).HasColumnName("additional_notes");
            entity.Property(e => e.QuantityRequests).HasColumnName("quantity_requests");
            entity.Property(e => e.RequestDate).HasColumnName("request_date");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(30)
                .HasColumnName("request_status");
            entity.Property(e => e.RequestTime).HasColumnName("request_time");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

            entity.HasOne(d => d.Service).WithMany(p => p.RequestServiceServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("request_service_service_id_fkey");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.RequestServiceUserAccounts)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("request_service_user_account_id_fkey");
        });

        modelBuilder.Entity<RequestServiceReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_service_review_pkey");

            entity.ToTable("request_service_review", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.PublishDate).HasColumnName("publish_date");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.RequestServiceId).HasColumnName("request_service_id");
            entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

            entity.HasOne(d => d.RequestService).WithMany(p => p.RequestServiceReviews)
                .HasForeignKey(d => d.RequestServiceId)
                .HasConstraintName("request_service_review_request_service_id_fkey");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.RequestServiceReviews)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("request_service_review_user_account_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role", "core");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("room_pkey");

            entity.ToTable("room", "core");

            entity.HasIndex(e => e.RoomNumber, "room_room_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");
            entity.Property(e => e.RoomType)
                .HasMaxLength(30)
                .HasColumnName("room_type");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("room_hotel_id_fkey");
        });

        modelBuilder.Entity<RoomComfort>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("room_comfort", "core");

            entity.Property(e => e.ComfortId).HasColumnName("comfort_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Comfort).WithMany()
                .HasForeignKey(d => d.ComfortId)
                .HasConstraintName("room_comfort_comfort_id_fkey");

            entity.HasOne(d => d.Room).WithMany()
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("room_comfort_room_id_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_pkey");

            entity.ToTable("service", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Services)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("service_hotel_id_fkey");
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("travel_pkey");

            entity.ToTable("travel", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrival_date");
            entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Travels)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("travel_hotel_id_fkey");
        });

        modelBuilder.Entity<TravelReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("travel_review_pkey");

            entity.ToTable("travel_review", "core");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.PublishDate).HasColumnName("publish_date");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.TravelId).HasColumnName("travel_id");
            entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

            entity.HasOne(d => d.Travel).WithMany(p => p.TravelReviews)
                .HasForeignKey(d => d.TravelId)
                .HasConstraintName("travel_review_travel_id_fkey");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.TravelReviews)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("travel_review_user_account_id_fkey");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_account_pkey");

            entity.ToTable("user_account", "core");

            entity.HasIndex(e => e.Email, "user_account_email_key").IsUnique();

            entity.HasIndex(e => e.Passport, "user_account_passport_key").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "user_account_phone_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Passport)
                .HasMaxLength(10)
                .HasColumnName("passport");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.Card).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_account_card_id_fkey");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_role", "core");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_role_id_fkey");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
