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
            var expected = new Configurations(_expectedUri);
            const string expectedConfigurationJsonified = "{\"redditApiEndpoint\": \"https://tdd.reddit.com/api/\"}";
            var mockedStreamReader = new Mock<TextReader>();
            mockedStreamReader.Setup(s => s.ReadToEndAsync()).ReturnsAsync(expectedConfigurationJsonified);

            var configurationsLoader = new ConfigurationsLoader();
            Configurations actual = await configurationsLoader.LoadAsync(mockedStreamReader.Object);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GivenValidFileWithUnusedParameters_Load_ValidConfigurationReturned()
        {
            var expected = new Configurations(_expectedUri);
            const string expectedConfigurationJsonified = "{\"redditApiEndpoint\": \"https://tdd.reddit.com/api/\",\"test\": \"test\"}";
            var mockedStreamReader = new Mock<TextReader>();
            mockedStreamReader.Setup(s => s.ReadToEndAsync()).ReturnsAsync(expectedConfigurationJsonified);

            var configurationsLoader = new ConfigurationsLoader();
            Configurations actual = await configurationsLoader.LoadAsync(mockedStreamReader.Object);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ConfigurationsLoadingException))]
        public async Task GivenNotExistingFile_Load_ConfigurationsLoadingExceptionThrown()
        {
            var mockedStreamReader = new Mock<TextReader>();
            mockedStreamReader.Setup(s => s.ReadToEndAsync()).ThrowsAsync(new FileNotFoundException("File not found."));

            var configurationsLoader = new ConfigurationsLoader();
            Configurations configurations = await configurationsLoader.LoadAsync(mockedStreamReader.Object);
        }

        [TestMethod, ExpectedException(typeof(ConfigurationsLoadingException))]
        public async Task GivenEmptyJson_Load_ConfigurationsLoadingExceptionThrown()
        {
            const string expectedConfigurationJsonified = "{\"redditApiEndpoint\": \"\"}";
            var mockedStreamReader = new Mock<TextReader>();
            mockedStreamReader.Setup(s => s.ReadToEndAsync()).ReturnsAsync(expectedConfigurationJsonified);
            
            var configurationsLoader = new ConfigurationsLoader();
            Configurations configurations = await configurationsLoader.LoadAsync(mockedStreamReader.Object);
        }

        [TestMethod, ExpectedException(typeof(ConfigurationsLoadingException))]
        public async Task GivenNullJson_Load_ConfigurationsLoadingExceptionThrown()
        {
            const string expectedConfigurationJsonified = "{\"redditApiEndpoint\": null}";
            var mockedStreamReader = new Mock<TextReader>();
            mockedStreamReader.Setup(s => s.ReadToEndAsync()).ReturnsAsync(expectedConfigurationJsonified);

            var configurationsLoader = new ConfigurationsLoader();
            Configurations configurations = await configurationsLoader.LoadAsync(mockedStreamReader.Object);
        }

        [TestMethod, ExpectedException(typeof(ConfigurationsLoadingException))]
        public async Task GivenInvalidJson_Load_ConfigurationsLoadingExceptionThrown()
        {
            const string expectedConfigurationJsonified = "{\"test\": \"test\"}";
            var mockedStreamReader = new Mock<TextReader>();
            mockedStreamReader.Setup(s => s.ReadToEndAsync()).ReturnsAsync(expectedConfigurationJsonified);

            var configurationsLoader = new ConfigurationsLoader();
            Configurations configurations = await configurationsLoader.LoadAsync(mockedStreamReader.Object);
        }
    }
}
