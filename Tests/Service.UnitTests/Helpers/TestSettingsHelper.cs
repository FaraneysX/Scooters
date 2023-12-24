using Service.Settings;

namespace Service.UnitTests.Helpers;

public static class TestSettingsHelper
{
    public static ScooterRentalSettings GetSettings()
    {
        return ScooterRentalSettingsReader.Read(ConfigurationHelper.GetConfiguration());
    }
}
