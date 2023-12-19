using ScooterRental.BL.Rents.Entities;

namespace ScooterRental.Service.Controllers.Entities.Rents;

public class RentsListResponse
{
    public List<RentModel>? Rents { get; set; }
}
