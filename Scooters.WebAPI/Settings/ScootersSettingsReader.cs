namespace Scooters.WebAPI.Settings
{
    public class ScootersSettingsReader
    {
        public static ScootersSettings Read(IConfiguration configuration)
        {
            return new ScootersSettings();
        }
    }
}
