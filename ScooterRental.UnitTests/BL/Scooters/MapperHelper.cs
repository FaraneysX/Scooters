using AutoMapper;

using ScooterRental.Service.Mapper;

namespace ScooterRental.UnitTests.BL.Scooters;

public static class MapperHelper
{
    public static IMapper Mapper { get; }

    static MapperHelper()
    {
        var config = new MapperConfiguration(x => x.AddProfile(typeof(ScootersServiceProfile)));
        Mapper = new Mapper(config);
    }
}
