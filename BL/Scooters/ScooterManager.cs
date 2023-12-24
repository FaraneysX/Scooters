using AutoMapper;

using BL.Scooters.Entities;

using DataAccess.Entities;
using DataAccess.Repository;

namespace BL.Scooters;

public class ScooterManager(IRepository<ScooterEntity> repository, IMapper mapper) : IManager<ScooterModel, CreateScooterModel>
{
    private readonly IRepository<ScooterEntity> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public ScooterModel Create(CreateScooterModel model)
    {
        var entity = _mapper.Map<ScooterEntity>(model);

        _repository.Save(entity);

        return _mapper.Map<ScooterModel>(entity);
    }

    public ScooterModel Update(Guid id, ScooterModel model)
    {
        var scooter = Find(id);

        scooter.Price = model.Price;
        scooter.ChargePercentage = model.ChargePercentage;
        scooter.Location = model.Location;
        scooter.Rents = (ICollection<RentEntity>?)model.Rents;

        _repository.Save(scooter);

        return _mapper.Map<ScooterModel>(scooter);
    }

    public void Delete(Guid id)
    {
        _repository.Delete(Find(id));
    }

    private ScooterEntity Find(Guid id)
    {
        return _repository.GetById(id) ?? throw new InvalidOperationException($"Scooter with ID {id} not found.");
    }
}
