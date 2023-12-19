using ScooterRental.BL.Scooters.Entities;

namespace ScooterRental.Service.Controllers.Entities.Scooters;

public class ScootersListResponse
{
    public List<ScooterModel>? Scooters { get; set; }
}
