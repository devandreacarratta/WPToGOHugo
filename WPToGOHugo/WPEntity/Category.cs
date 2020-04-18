namespace WPToGOHugo.WPEntity
{
    internal class Category
    {
        public long term_id { get; set; }

        public string name { get; set; }

        public string slug { get; set; }

        public long term_group { get; set; }

        public long term_taxonomy_id { get; set; }

        public string taxonomy { get; set; }

        public string description { get; set; }

        public long parent { get; set; }

        public long count { get; set; }

        public string filter { get; set; }

        public long cat_ID { get; set; }

        public long category_count { get; set; }

        public string category_description { get; set; }

        public string cat_name { get; set; }

        public string category_nicename { get; set; }

        public long category_parent { get; set; }
    }
}