using ScooterRental.BL;
using ScooterRental.BL.Rents;
using ScooterRental.BL.Rents.Entities;
using ScooterRental.BL.Scooters;
using ScooterRental.BL.Scooters.Entities;
using ScooterRental.BL.Users;
using ScooterRental.BL.Users.Entities;
using ScooterRental.DataAccess.Repository;

namespace ScooterRental.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProvider<RentModel, RentsModelFilter>, RentProvider>();
        services.AddScoped<IManager<RentModel, CreateRentModel>, RentManager>();

        services.AddScoped<IProvider<ScooterModel, ScootersModelFilter>, ScooterProvider>();
        services.AddScoped<IManager<ScooterModel, CreateScooterModel>, ScooterManager>();

        services.AddScoped<IProvider<UserModel, UsersModelFilter>, UserProvider>();
        services.AddScoped<IManager<UserModel, CreateUserModel>, UserManager>();
    }
}
