using System;

namespace Configuration
{
    class ConfigurationLoadingException : Exception
    {
        public ConfigurationLoadingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
