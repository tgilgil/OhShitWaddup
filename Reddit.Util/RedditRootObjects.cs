using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// This class has been auto-generated with http://json2csharp.com/
/// </summary>
namespace Reddit.Util
{
    public class Comment
    {
        public string subreddit_id { get; set; }
        public string link_title { get; set; }
        public object banned_by { get; set; }
        public object removal_reason { get; set; }
        public string link_id { get; set; }
        public string link_author { get; set; }
        public object likes { get; set; }
        public string replies { get; set; }
        public List<object> user_reports { get; set; }
        public bool saved { get; set; }
        public string id { get; set; }
        public int gilded { get; set; }
        public bool archived { get; set; }
        public bool stickied { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        public string parent_id { get; set; }
        public int score { get; set; }
        public object approved_by { get; set; }
        public bool over_18 { get; set; }
        public object report_reasons { get; set; }
        public int controversiality { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        public bool edited { get; set; }
        public string author_flair_css_class { get; set; }
        public int downs { get; set; }
        public string body_html { get; set; }
        public bool quarantine { get; set; }
        public string subreddit { get; set; }
        public bool score_hidden { get; set; }
        public string name { get; set; }
        public double created { get; set; }
        public string author_flair_text { get; set; }
        public string link_url { get; set; }
        public double created_utc { get; set; }
        public int ups { get; set; }
        public List<object> mod_reports { get; set; }
        public object num_reports { get; set; }
        public object distinguished { get; set; }
    }

    public class CommentAndKind
    {
        public string kind { get; set; }
        [JsonProperty("data")]
        public Comment Comment { get; set; }
    }

    public class Data
    {
        public string modhash { get; set; }
        [JsonProperty("children")]
        public List<CommentAndKind> Comments { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }

    public class RootRedditObject
    {
        public string kind { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
