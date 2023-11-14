using System.ComponentModel.DataAnnotations;

namespace Scooters.DataAccess.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid ExternalId { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public DateTime ModificationTime { get; set; }
    }
}
