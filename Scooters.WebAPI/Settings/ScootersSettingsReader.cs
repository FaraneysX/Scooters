namespace Scooters.WebAPI.Settings
{
    public static class ScootersSettingsReader
    {
        public static ScootersSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new ScootersSettings();
        }
    }
}
