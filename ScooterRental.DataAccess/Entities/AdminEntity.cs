using System.ComponentModel.DataAnnotations.Schema;

namespace ScooterRental.DataAccess.Entities;

[Table("admins")]
public class AdminEntity : BaseEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}
