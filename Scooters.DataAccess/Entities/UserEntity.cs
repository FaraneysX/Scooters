using System.ComponentModel.DataAnnotations;

namespace Scooters.DataAccess.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public virtual ICollection<RentEntity>? Rents { get; set; }

        public AdminEntity? Admin { get; set; }

        public UserEntity()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            PasswordHash = string.Empty;
        }
    }
}
