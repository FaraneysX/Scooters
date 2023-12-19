using AutoMapper;

using ScooterRental.BL.Rents.Entities;
using ScooterRental.Service.Controllers.Entities.Rents;

namespace ScooterRental.Service.Mapper;

public class RentsServiceProfile : Profile
{
    public RentsServiceProfile()
    {
        CreateMap<RentsFilter, RentsModelFilter>();
        CreateMap<CreateRentRequest, CreateRentModel>();
        CreateMap<UpdateRentRequest, UpdateRentModel>();
    }
}
