using System;

namespace Configuration
{
    public class Configurations
    {
        public string RedditApiEndpoint { get; }

        public Configurations(string redditApiEndpoint)
        {
            if (string.IsNullOrEmpty(redditApiEndpoint))
                throw new ArgumentNullException(nameof(redditApiEndpoint));

            RedditApiEndpoint = redditApiEndpoint;
        }
    }
}
