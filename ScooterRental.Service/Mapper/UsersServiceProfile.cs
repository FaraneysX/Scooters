using AutoMapper;

using ScooterRental.BL.Users.Entities;
using ScooterRental.Service.Controllers.Entities.Users;

namespace ScooterRental.Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UsersFilter, UsersModelFilter>();
        CreateMap<CreateUserRequest, CreateUserModel>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
    }
}
