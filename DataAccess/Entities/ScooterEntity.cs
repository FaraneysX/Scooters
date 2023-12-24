using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("scooters")]
public class ScooterEntity : BaseEntity
{
    public required double Price { get; set; }
    public required double ChargePercentage { get; set; }
    public string? Location { get; set; }
    public virtual ICollection<RentEntity>? Rents { get; set; }
}
