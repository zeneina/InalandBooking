using InalandBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace InalandBooking.Data
{
    public class InalandBookingDbContext : DbContext
    {
        public InalandBookingDbContext(DbContextOptions<InalandBookingDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");
                entity.HasIndex(e => e.Lastname, "IX_LASTNAME");
                entity.HasIndex(e => e.Username, "UQ_USERNAME").IsUnique();
                entity.HasIndex(e => e.Email, "UQ_EMAIL").IsUnique();
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Username)
                    .HasMaxLength(50).HasColumnName("USERNAME");
                entity.Property(e => e.Password)
                    .HasMaxLength(512).HasColumnName("PASSWORD");
                entity.Property(e => e.Email)
                    .HasMaxLength(50).HasColumnName("EMAIL");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(50).HasColumnName("FIRSTNAME");
                entity.Property(e => e.Lastname)
                    .HasMaxLength(50).HasColumnName("LASTNAME");
                entity.Property(e => e.UserRole)
                    .HasColumnName("USER_ROLE")
                    .HasConversion<string>()
                    .HasMaxLength(50);
                // .IsRequired();              
            });

          

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("BOOKINGS");
               // entity.Property(e => e.Id).HasColumnName("ID");
                // Define other booking mappings
            });

            
        }
    }
}
