using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Configuration
{
    public class ConfigurationsLoader
    {
        public async Task<Configurations> LoadAsync(TextReader streamReader)
        {
            try
            {
                using (streamReader)
                {
                    var json = await streamReader.ReadToEndAsync();
                    var configuration = await Task.Run(() => JsonConvert.DeserializeObject<Configurations>(json));

                    return configuration;
                }
            }
            catch (Exception innerException)
            {
                throw new ConfigurationsLoadingException("An error has occured while loading the configuration JSON file.", innerException);
            }
        }
    }
}
