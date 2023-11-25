using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScooterRental.DataAccess.Entities;

[Table("reviews")]
public class ReviewEntity : BaseEntity
{
    public string? Text { get; set; }

    [Range(0, 5)]
    public int Rating { get; set; }

    public int RentId { get; set; }
    public RentEntity Rent { get; set; }
}
