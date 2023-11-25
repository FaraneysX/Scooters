using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScooterRental.DataAccess.Entities;

[Table("scooters")]
public class ScooterEntity : BaseEntity
{
    public double Price { get; set; }

    [Range(0, 100)]
    public double ChargePercentage { get; set; }

    public string Location { get; set; }
    public virtual ICollection<RentEntity>? Rents { get; set; }
}
