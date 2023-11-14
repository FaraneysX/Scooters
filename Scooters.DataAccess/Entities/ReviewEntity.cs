using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scooters.DataAccess.Entities
{
    [Table("reviews")]
    public class ReviewEntity : BaseEntity
    {
        [Required]
        public int RentId { get; set; }

        [Required]
        public RentEntity Rent { get; set; }

        public string? Text { get; set; }

        [Required]
        public int Rating { get; set; }

        public ReviewEntity()
        {
            Rent = new RentEntity();
        }
    }
}
