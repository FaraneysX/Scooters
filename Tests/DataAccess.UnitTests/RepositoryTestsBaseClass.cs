using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Service.Settings;

namespace DataAccess.UnitTests;

public class RepositoryTestsBaseClass
{
    protected readonly ScooterRentalSettings _settings;
    protected readonly IDbContextFactory<ScooterRentalDbContext> _dbContextFactory;
    protected readonly IServiceProvider _serviceProvider;

    public RepositoryTestsBaseClass()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Test.json", optional: true)
            .Build();

        _settings = ScooterRentalSettingsReader.Read(configuration);
        _serviceProvider = ConfigureServiceProvider;
        _dbContextFactory = _serviceProvider.GetRequiredService<IDbContextFactory<ScooterRentalDbContext>>();
    }

    private IServiceProvider ConfigureServiceProvider
    {
        get
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContextFactory<ScooterRentalDbContext>(
                options => options.UseSqlServer(_settings.ScooterRentalDbContextConnectionString),
                        ServiceLifetime.Scoped);

            return serviceCollection.BuildServiceProvider();
        }
    }
}
