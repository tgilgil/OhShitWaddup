using System;

namespace Reddit
{
    public class Comment
    {
        public string Author { get; }
        public string Body { get; }

        public Comment(string author, string body)
        {
            if (string.IsNullOrEmpty(author)) throw new ArgumentNullException(nameof(author));
            if (string.IsNullOrEmpty(body)) throw new ArgumentNullException(nameof(body));

            Author = author;
            Body = body;
        }

        public override bool Equals(object obj)
        {
            var comment = obj as Comment;

            if (comment == null)
                return false;

            return comment.Author == Author && comment.Body == Body;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
