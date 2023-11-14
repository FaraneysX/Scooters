using Microsoft.EntityFrameworkCore;

using Scooters.DataAccess;
using Scooters.Service.Settings;

namespace Scooters.Service.IoC
{
    public static class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, ScootersSettings settings)
        {
            services.AddDbContextFactory<ScootersDbContext>(
                options =>
                {
                    options.UseSqlServer(settings.ScootersDbContextConnectionString);
                },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ScootersDbContext>>();
            using var context = contextFactory.CreateDbContext();

            context.Database.Migrate();
        }
    }
}