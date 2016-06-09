using System;

namespace Configuration
{
    public class ConfigurationsLoadingException : Exception
    {
        public ConfigurationsLoadingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
