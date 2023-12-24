using AutoMapper;

using Service.Mapper;

namespace BL.UnitTests.Scooters;

public static class MapperHelper
{
    public static IMapper Mapper { get; }

    static MapperHelper()
    {
        var config = new MapperConfiguration(x => x.AddProfile(typeof(ScootersServiceProfile)));
        Mapper = new AutoMapper.Mapper(config);
    }
}
