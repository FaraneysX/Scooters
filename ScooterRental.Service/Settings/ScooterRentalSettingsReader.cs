namespace ScooterRental.Service.Settings;

public static class ScooterRentalSettingsReader
{
    public static ScooterRentalSettings Read(IConfiguration configuration) => new()
    {
        ScooterRentalDbContextConnectionString = configuration.GetValue<string>("ScooterRentalDbContext")
    };
}
