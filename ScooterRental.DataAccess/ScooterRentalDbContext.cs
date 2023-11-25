using ScooterRental.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ScooterRental.DataAccess;

public class ScooterRentalDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AdminEntity> Admins { get; set; }
    public DbSet<ScooterEntity> Scooters { get; set; }
    public DbSet<RentEntity> Rents { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }

    public ScooterRentalDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasOne(user => user.Admin)
            .WithOne(admin => admin.User);

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
