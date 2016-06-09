using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace Reddit.Tests
{
    [TestClass]
    public class ReplyTests
    {
        [TestMethod]
        public void GivenValidParameters_Constructor_JsonificationPossible()
        {
            Reply expected = new Reply("Snoo", "Frontpage of the internet.");

            var actualJson = JsonConvert.SerializeObject(expected);
            var actual = JsonConvert.DeserializeObject<Reply>(actualJson);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullReplyingTo_Constructor_ArgumentNullException()
        {
            Reply comment = new Reply(null, "Frontpage of the internet.");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenEmptyReplyingTo_Constructor_ArgumentNullException()
        {
            Reply comment = new Reply(string.Empty, "Frontpage of the internet.");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullBody_Constructor_ArgumentNullException()
        {
            Reply comment = new Reply("Snoo", null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenEmptyBodyConstructor__ArgumentNullException()
        {
            Reply comment = new Reply("Snoo", string.Empty);
        }
    }
}
