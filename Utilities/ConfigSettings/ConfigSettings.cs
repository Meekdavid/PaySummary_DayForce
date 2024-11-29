using PaySummary_DayForce.Utilities.ConfigSettings.ConfigModels;

namespace PaySummary_DayForce.Utilities.ConfigSettings
{
    public static class ConfigSettings
    {
        public static ConnectionStrings ConnectionString => ConfigurationSettingsHelper.GetConfigurationSectionObject<ConnectionStrings>("ConnectionStrings");
        public static ConfigParameters ConfigParameter => ConfigurationSettingsHelper.GetConfigurationSectionObject<ConfigParameters>("ConfigParameters");
    }
}
