namespace PaySummary_DayForce.Utilities.ConfigSettings
{
    public class ConfigurationSettingsHelper
    {
        private static IConfiguration _Configuration { get; set; }

        public static IConfiguration Configuration
        {
            set
            {
                _Configuration = value;
            }
        }

        public static T GetConfigurationSectionObject<T>(string configurationSectionPropertyName) where T : class
        {
            return _Configuration.GetSection(configurationSectionPropertyName).Get<T>();
        }
    }
}
