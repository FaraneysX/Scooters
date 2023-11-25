using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScooterRental.DataAccess.Entities;

[Table("rents")]
public class RentEntity : BaseEntity
{
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }

    [Range(0, double.MaxValue)]
    public double TotalPrice { get; set; }

    public UserEntity User { get; set; }
    public virtual ICollection<ScooterEntity> Scooters { get; set; }
    public ReviewEntity? Review { get; set; }
}
