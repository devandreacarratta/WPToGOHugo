using System.Collections.Generic;

namespace WPToGOHugo.WPEntity
{
    internal class PostCollection : List<Post> { }

    internal class Post
    {
        public long id { get; set; }

        public string slug { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public string link { get; set; }

        public List<Category> category { get; set; } = new List<Category>();

        public Tags tags { get; set; }

        public string pubDate { get; set; }

        public string dcCreator { get; set; }

        public string seo_metadesc { get; set; }
        public string seo_image { get; set; }
        public string seo_focuskw { get; set; }
    }
}