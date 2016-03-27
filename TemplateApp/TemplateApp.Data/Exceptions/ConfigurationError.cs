using System;

namespace TemplateApp.Data.Exceptions
{
    [Serializable]
    public class ConfigurationError : Exception
    {
        public ConfigurationError()
        {
        }

        public ConfigurationError(string settingName)
            : base(errorMessage(settingName))
        {
        }

        private static string errorMessage(string settingName)
        {
            return string.Format("{0} was not found in the application configuration or the environment variables.", settingName);
        }
    }
}