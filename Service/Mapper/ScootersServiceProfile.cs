using AutoMapper;

using BL.Scooters.Entities;

using Service.Controllers.Entities.Scooters;

namespace Service.Mapper;

public class ScootersServiceProfile : Profile
{
    public ScootersServiceProfile()
    {
        CreateMap<ScootersFilter, ScootersModelFilter>();
        CreateMap<CreateScooterRequest, CreateScooterModel>();
        CreateMap<UpdateScooterRequest, UpdateScooterModel>();
    }
}
