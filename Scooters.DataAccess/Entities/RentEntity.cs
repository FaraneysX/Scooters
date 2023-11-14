using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scooters.DataAccess.Entities
{
    [Table("rents")]
    public class RentEntity : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public UserEntity User { get; set; }

        [Required]
        public int ScooterId { get; set; }

        [Required]
        public ScooterEntity Scooter { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public double TotalPrice { get; set; }

        public int ReviewId { get; set; }

        public ReviewEntity? Review { get; set; }

        public RentEntity()
        {
            User = new UserEntity();
            Scooter = new ScooterEntity();
        }
    }
}
