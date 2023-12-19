using AutoMapper;

using ScooterRental.BL.Scooters.Entities;
using ScooterRental.Service.Controllers.Entities.Scooters;

namespace ScooterRental.Service.Mapper;

public class ScootersServiceProfile : Profile
{
    public ScootersServiceProfile()
    {
        CreateMap<ScootersFilter, ScootersModelFilter>();
        CreateMap<CreateScooterRequest, CreateScooterModel>();
        CreateMap<UpdateScooterRequest, UpdateScooterModel>();
    }
}
