using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scooters.DataAccess.Entities
{
    [Table("admins")]
    public class AdminEntity : UserEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public UserEntity User { get; set; }

        public AdminEntity()
        {
            User = new UserEntity();
        }
    }
}
