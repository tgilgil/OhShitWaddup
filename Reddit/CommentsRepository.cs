using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Reddit.Util;
using System.Linq;

namespace Reddit
{
    public class CommentsRepository : ICommentsRepository
    {
        private HttpClient _httpClient;
        private Uri _apiEndpoint;

        public CommentsRepository(HttpClient httpClient, Uri apiEndpoint)
        {
            _httpClient = httpClient;
            _apiEndpoint = apiEndpoint;
        }

        /// <summary>
        /// Get all comments from /r/all
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> Get()
        {
            return await ToComments(await _httpClient.GetAsync(_apiEndpoint));
        }

        /// <summary>
        /// Post a reply
        /// </summary>
        /// <param name="comment"></param>
        public void Post(Reply reply)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<Comment>> ToComments(HttpResponseMessage response)
        {
            RootRedditObject rootRedditObject = new RootRedditObject();

            try
            {
                rootRedditObject = JsonConvert.DeserializeObject<RootRedditObject>(await response.Content.ReadAsStringAsync());

                return rootRedditObject.Data.Comments.Select(c => new Comment(c.Comment.Author, c.Comment.Body));
            }
            catch (Exception e)
            {
                throw new RedditCommentsFormatException("The comments returned are not in the expected format", e);
            }
        }
    }
}
