namespace ScooterRental.BL.Rents.Entities;

public class UpdateRentModel
{
    public Guid? UserId { get; set; }
    public virtual ICollection<Guid>? ScootersId { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public double? TotalPrice { get; set; }
    public Guid? ReviewId { get; set; }
}
