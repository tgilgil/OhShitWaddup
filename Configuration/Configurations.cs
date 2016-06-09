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

        public override bool Equals(object obj)
        {
            var configurations = obj as Configurations;

            if (configurations == null)
                return false;

            return RedditApiEndpoint == configurations.RedditApiEndpoint;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
