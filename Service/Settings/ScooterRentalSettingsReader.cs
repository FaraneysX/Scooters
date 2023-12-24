namespace Service.Settings;

public static class ScooterRentalSettingsReader
{
    public static ScooterRentalSettings Read(IConfiguration configuration) => new()
    {
        ServiceUri = configuration.GetValue<Uri>("Uri"),
        ScooterRentalDbContextConnectionString = configuration.GetValue<string>("ScooterRentalDbContext"),
        IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
        ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
        ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
    };
}
