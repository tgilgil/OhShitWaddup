namespace Configuration
{
    public class Configuration
    {
        public string RedditApiEndpoint { get; }

        public Configuration(string redditApiEndpoint)
        {
            RedditApiEndpoint = redditApiEndpoint;
        }
    }
}
