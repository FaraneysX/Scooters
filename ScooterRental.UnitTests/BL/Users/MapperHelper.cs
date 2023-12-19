using AutoMapper;

using ScooterRental.Service.Mapper;

namespace ScooterRental.UnitTests.BL.Users;

public static class MapperHelper
{
    public static IMapper Mapper { get; }

    static MapperHelper()
    {
        var config = new MapperConfiguration(x => x.AddProfile(typeof(UsersServiceProfile)));
        Mapper = new Mapper(config);
    }
}
