using Microsoft.EntityFrameworkCore;
using Scooters.DataAccess.Entities;

namespace Scooters.DataAccess
{
    public class ScootersDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdminEntity> Employees { get; set; }
        public DbSet<RentEntity> Rents { get; set; }
        public DbSet<ScooterEntity> Scooters { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }

        public ScootersDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseEntity>()
                .HasIndex(entity => entity.ExternalId)
                .IsUnique();

            void UserAdminSettings()
            {
                modelBuilder.Entity<UserEntity>()
                    .HasOne(user => user.Admin)
                    .WithOne(admin => admin.User)
                    .IsRequired(false);

                modelBuilder.Entity<AdminEntity>()
                    .HasOne(admin => admin.User)
                    .WithOne(user => user.Admin);
            }

            void UserRentSettings()
            {
                modelBuilder.Entity<UserEntity>()
                    .HasMany(user => user.Rents)
                    .WithOne(rent => rent.User)
                    .HasForeignKey(rent => rent.UserId)
                    .IsRequired(false);

                modelBuilder.Entity<RentEntity>()
                    .HasOne(rent => rent.User)
                    .WithMany(user => user.Rents);
            }

            void RentScooterSettings()
            {
                modelBuilder.Entity<RentEntity>()
                    .HasOne(rent => rent.Scooter)
                    .WithMany(scooter => scooter.Rents)
                    .HasForeignKey(rent => rent.ScooterId);
                
                modelBuilder.Entity<ScooterEntity>()
                    .HasMany(scooter => scooter.Rents)
                    .WithOne(rent => rent.Scooter)
                    .IsRequired(false);
            }

            void RentReviewSettings()
            {
                modelBuilder.Entity<RentEntity>()
                    .HasOne(rent => rent.Review)
                    .WithOne(review => review.Rent)
                    .IsRequired(false);

                modelBuilder.Entity<ReviewEntity>()
                    .HasOne(review => review.Rent)
                    .WithOne(rent => rent.Review);
            }

            UserAdminSettings();
            UserRentSettings();
            RentScooterSettings();
            RentReviewSettings();
        }
    }
}
