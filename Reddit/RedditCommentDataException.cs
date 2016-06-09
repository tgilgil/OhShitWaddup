using System;

namespace Reddit
{
    [Serializable]
    public class RedditCommentsFormatException : Exception
    {
        public RedditCommentsFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
