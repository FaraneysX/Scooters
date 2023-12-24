using DataAccess;

using Microsoft.EntityFrameworkCore;

using Service.Settings;

namespace Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, ScooterRentalSettings settings)
    {
        services.AddDbContextFactory<ScooterRentalDbContext>(
            options => options.UseSqlServer(settings.ScooterRentalDbContextConnectionString),
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ScooterRentalDbContext>>();
        using var context = contextFactory.CreateDbContext();

        context.Database.Migrate();
    }
}
