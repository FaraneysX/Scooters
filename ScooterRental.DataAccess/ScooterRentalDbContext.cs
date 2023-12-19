using Microsoft.EntityFrameworkCore;

using ScooterRental.DataAccess.Entities;

namespace ScooterRental.DataAccess;

public class ScooterRentalDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ScooterEntity> Scooters { get; set; }
    public DbSet<RentEntity> Rents { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
                    .HasMany(user => user.Rents)
                    .WithOne(rent => rent.User);

        modelBuilder.Entity<RentEntity>()
                    .HasMany(rent => rent.Scooters)
                    .WithMany(scooter => scooter.Rents);

        modelBuilder.Entity<RentEntity>()
                    .HasOne(rent => rent.Review)
                    .WithOne(review => review.Rent);
    }
}
