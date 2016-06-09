using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Reddit.Tests
{
    [TestClass]
    public class CommentTests
    {
        [TestMethod]
        public void GivenValidParameters_Constructor_JsonificationPossible()
        {
            Comment expected = new Comment("Snoo", "Frontpage of the internet.");

            var actualJson = JsonConvert.SerializeObject(expected);
            var actual = JsonConvert.DeserializeObject<Comment>(actualJson);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullAuthor_Constructor_ArgumentNullException()
        {
            Comment comment = new Comment(null, "Frontpage of the internet.");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenEmptyAuthor_Constructor_ArgumentNullException()
        {
            Comment comment = new Comment(string.Empty, "Frontpage of the internet.");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullBody_Constructor_ArgumentNullException()
        {
            Comment comment = new Comment("Snoo", null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GivenEmptyBody_Constructor_ArgumentNullException()
        {
            Comment comment = new Comment("Snoo", string.Empty);
        }
    }
}
