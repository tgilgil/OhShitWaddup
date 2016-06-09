using Newtonsoft.Json;
using System;
using System.IO;

namespace Configuration
{
    public class ConfigurationLoader
    {
        private readonly string _configurationFileName;

        public ConfigurationLoader(string configurationFileName)
        {
            _configurationFileName = configurationFileName;
        }

        public Configuration Load()
        {
            try
            {
                using (StreamReader r = new StreamReader("file.json"))
                {
                    string json = r.ReadToEnd();
                    var configuration = JsonConvert.DeserializeObject<Configuration>(json);

                    return configuration;
                }
            }
            catch (Exception innerException)
            {
                throw new ConfigurationLoadingException("An error has occured while laoding the configuration JSON file.", innerException);
            }
        }
    }
}
