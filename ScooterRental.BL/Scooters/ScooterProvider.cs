using AutoMapper;

using ScooterRental.BL.Scooters.Entities;
using ScooterRental.DataAccess.Entities;
using ScooterRental.DataAccess.Repository;

namespace ScooterRental.BL.Scooters;

public class ScooterProvider(IRepository<ScooterEntity> scootersRepository, IMapper mapper) : IProvider<ScooterModel, ScootersModelFilter>
{
    private readonly IRepository<ScooterEntity> _repository = scootersRepository;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<ScooterModel> Get(ScootersModelFilter? modelFilter)
    {
        double? minPrice = modelFilter?.MinPrice;
        double? maxPrice = modelFilter?.MaxPrice;
        double? minChargePercentage = modelFilter?.MinChargePercentage;
        double? maxChargePercentage = modelFilter?.MaxChargePercentage;
        string? location = modelFilter?.Location;

        var scooters = _repository.GetAll(scooter => (
        (minPrice == null || scooter.Price >= minPrice) &&
        (maxPrice == null || scooter.Price <= maxPrice) &&
        (minChargePercentage == null || scooter.ChargePercentage >= minPrice) &&
        (maxChargePercentage == null || scooter.ChargePercentage <= maxChargePercentage) &&
        (location == null || scooter.Location == location)
        ));

        return _mapper.Map<IEnumerable<ScooterModel>>(scooters);
    }

    public ScooterModel GetInfo(Guid id)
    {
        return _mapper.Map<ScooterModel>(Find(id));
    }

    private ScooterEntity Find(Guid id)
    {
        return _repository.GetById(id) ?? throw new InvalidOperationException($"Scooter with ID {id} not found.");
    }
}
