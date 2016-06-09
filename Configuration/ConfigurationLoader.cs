using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public static void Load()
        {
            try
            {
                using (StreamReader r = new StreamReader("file.json"))
                {
                    string json = r.ReadToEnd();
                    List<Configuration> items = JsonConvert.DeserializeObject<List<Configuration>>(json);
                }
            }
            catch (Exception innerException)
            {
                throw new ConfigurationLoadingException("An error has occured while laoding the configuration JSON file.", innerException);
            }
        }
    }
}
