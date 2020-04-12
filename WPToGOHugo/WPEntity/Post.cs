using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WPToGOHugo.WPEntity
{
    internal class PostCollection : List<Post> { }

    internal class Post
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("category")]
        public List<Category> Category { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("pubDate")]
        public string PubDate { get; set; }

        [JsonProperty("dcCreator")]
        public string DcCreator { get; set; }

        [JsonProperty("seo_metadesc")]
        public string SeoMetadesc { get; set; }
    }
}
