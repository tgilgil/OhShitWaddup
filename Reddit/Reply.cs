using System;

namespace Reddit
{
    public class Reply
    {
        public string ReplyingTo { get; }
        public string Body { get; }

        public Reply(string replyingTo, string body)
        {
            if (string.IsNullOrEmpty(replyingTo)) throw new ArgumentNullException(nameof(replyingTo));
            if (string.IsNullOrEmpty(body)) throw new ArgumentNullException(nameof(body));
            
            ReplyingTo = replyingTo;
            Body = body;
        }

        public override bool Equals(object obj)
        {
            var reply = obj as Reply;

            if (reply == null)
                return false;

            return reply.ReplyingTo == ReplyingTo && reply.Body == Body;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
