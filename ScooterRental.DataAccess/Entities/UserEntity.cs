using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScooterRental.DataAccess.Entities;

[Table("users")]
public class UserEntity : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    public string PasswordHash { get; set; }
    public virtual ICollection<RentEntity>? Rents { get; set; }
    public AdminEntity? Admin { get; set; }
}
