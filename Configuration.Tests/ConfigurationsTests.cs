using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class ConfigurationsTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenEmptyRedditApiEndpoint_Construtor_ArgumentNullExceptionThrown()
        {
            Configurations configuration = new Configurations(string.Empty);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullRedditApiEndpoint_Constructor_ArgumentNullExceptionThrown()
        {
            Configurations configuration = new Configurations(null);
        }
    }
}
