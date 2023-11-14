using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scooters.DataAccess.Entities
{
    [Table("scooters")]
    public class ScooterEntity : BaseEntity
    {
        [Required]
        public double Price { get; set; }

        [Required]
        public double ChargePercentage { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<RentEntity>? Rents { get; set; }

        public ScooterEntity()
        {
            Location = string.Empty;
        }
    }
}