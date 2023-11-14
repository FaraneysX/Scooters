namespace Scooters.Service.Settings
{
    public class ScootersSettingsReader
    {
        public static ScootersSettings Read(IConfiguration configuration)
        {
            return new ScootersSettings()
            {
                ScootersDbContextConnectionString = configuration.GetValue<string>("ScootersDbContext")
            };
        }
    }
}
