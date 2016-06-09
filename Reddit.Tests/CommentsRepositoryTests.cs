using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Moq;
using System.Threading.Tasks;
using Moq.Protected;
using System.Threading;
using System.Net;
using System.Linq;
using Reddit.Util;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Reddit.Tests
{
    [TestClass]
    public class CommentsRepositoryTests
    {
        [TestMethod]
        public async Task GivenValidApi_Get_CommentsReturned()
        {
            const string expectedBaseAddress = "https://reddit.com/r/all/comments.json";
            string expectedResponseContent = JsonConvert.SerializeObject(GetFakeRedditComments());
            ICommentsRepository repository = new CommentsRepository(new HttpClient(GetMockedHttpMessageHandler(expectedResponseContent)), new Uri(expectedBaseAddress));

            var actual = await repository.Get();
            
            Assert.IsTrue(actual.Any());
            Assert.AreEqual(2, actual.Count());
        }

        [TestMethod, ExpectedException(typeof(RedditCommentsFormatException))]
        public async Task GivenInvalidResponse_Get_RedditCommentsFormatExceptionThrown()
        {
            const string expectedBaseAddress = "https://reddit.com/r/all/comments.json";
            string expectedResponseContent = JsonConvert.SerializeObject(new { UnexpectedProperty = "InvalidObject" });
            ICommentsRepository repository = new CommentsRepository(new HttpClient(GetMockedHttpMessageHandler(expectedResponseContent)), new Uri(expectedBaseAddress));

            var actual = await repository.Get();

            Assert.IsTrue(actual.Any());
            Assert.AreEqual(2, actual.Count());
        }

        #region util methods for simplifying testing
        private RootRedditObject GetFakeRedditComments()
        {
            var expectedComments = new RootRedditObject
            {
                Data = new Data
                {
                    Comments = new List<CommentAndKind>
                    {
                        new CommentAndKind
                        {
                            Comment = new Util.Comment
                            {
                                Author = "Snoo",
                                Body = "Frontpage of the internet."
                            }
                        },
                        new CommentAndKind
                        {
                            Comment = new Util.Comment
                            {
                                Author = "Pao",
                                Body = "Burn everything."
                            }
                        }
                    }
                }
            };

            return expectedComments;
        }

        private HttpMessageHandler GetMockedHttpMessageHandler(string expectedJsonContent, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var handler = new Mock<HttpMessageHandler>();

            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    var result = new HttpResponseMessage(expectedStatusCode);
                    result.Content = new StringContent(expectedJsonContent);
                    return result;
                }))
                .Callback<HttpRequestMessage, CancellationToken>((r, c) =>
                {
                    Assert.AreEqual(HttpMethod.Get, r.Method);
                });

            return handler.Object;
        }
        #endregion
    }
}
