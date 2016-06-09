using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Threading.Tasks;

namespace Configuration.Tests
{
    [TestClass]
    public class ConfigurationsLoaderTests
    {
        private readonly string _expectedUri = "https://tdd.reddit.com/api/";

        [TestMethod]
        public async Task GivenValidFile_Load_ValidConfigurationReturned()
        {
            const string expectedConfigurationJsonified = "{\"redditApiEndpoint\": \"https://tdd.reddit.com/api/\"}";
            var mockedStreamReader = new Mock<TextReader>();
            mockedStreamReader.Setup(s => s.ReadToEndAsync()).ReturnsAsync(expectedConfigurationJsonified);

            var configurationsLoader = new ConfigurationsLoader();
            Configurations configurations = await configurationsLoader.LoadAsync(mockedStreamReader.Object);

            Assert.AreEqual(_expectedUri, configurations.RedditApiEndpoint);
        }

        [TestMethod, ExpectedException(typeof(ConfigurationsLoadingException))]
        public async Task GivenNotExistingFile_Load_ConfigurationsLoadingExeptionThrown()
        {
            var mockedStreamReader = new Mock<TextReader>();
            mockedStreamReader.Setup(s => s.ReadToEndAsync()).ThrowsAsync(new FileNotFoundException("File not found."));

            var configurationsLoader = new ConfigurationsLoader();
            Configurations configurations = await configurationsLoader.LoadAsync(mockedStreamReader.Object);

            Assert.AreEqual(_expectedUri, configurations.RedditApiEndpoint);
        }
    }
}
