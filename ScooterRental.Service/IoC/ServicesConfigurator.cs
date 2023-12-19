using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

using ScooterRental.BL;
using ScooterRental.BL.Auth;
using ScooterRental.BL.Rents;
using ScooterRental.BL.Rents.Entities;
using ScooterRental.BL.Scooters;
using ScooterRental.BL.Scooters.Entities;
using ScooterRental.BL.Users;
using ScooterRental.BL.Users.Entities;
using ScooterRental.DataAccess.Entities;
using ScooterRental.DataAccess.Repository;
using ScooterRental.Service.Settings;

namespace ScooterRental.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, ScooterRentalSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProvider<UserModel, UsersModelFilter>>(x => new UserProvider(x.GetRequiredService<IRepository<UserEntity>>(), x.GetRequiredService<IMapper>()));

        services.AddScoped<IAuthProvider>(x =>
                new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));

        services.AddScoped<IManager<RentModel, CreateRentModel>, RentManager>();
        services.AddScoped<IManager<ScooterModel, CreateScooterModel>, ScooterManager>();
        services.AddScoped<IManager<UserModel, CreateUserModel>, UserManager>();
    }
}
