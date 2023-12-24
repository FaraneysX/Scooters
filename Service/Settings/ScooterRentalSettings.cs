namespace Service.Settings;

public class ScooterRentalSettings
{
    public required Uri ServiceUri { get; set; }
    public required string ScooterRentalDbContextConnectionString { get; set; }
    public required string IdentityServerUri { get; set; }
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
}
