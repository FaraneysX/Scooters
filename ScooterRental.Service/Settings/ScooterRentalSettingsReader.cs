namespace ScooterRental.Service.Settings;

public static class ScooterRentalSettingsReader
{
    public static ScooterRentalSettings Read(IConfiguration configuration)
    {
        return new ScooterRentalSettings()
        {
            ScooterRentalDbContextConnectionString = configuration.GetValue<string>("ScooterRentalDbContext")
        };
    }
}
