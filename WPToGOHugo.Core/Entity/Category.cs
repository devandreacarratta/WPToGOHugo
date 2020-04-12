using Newtonsoft.Json;

namespace WPToGOHugo.Core.Entity
{
    public  class Category
    {
        [JsonProperty("term_id")]
        public long TermId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("term_group")]
        public long TermGroup { get; set; }

        [JsonProperty("term_taxonomy_id")]
        public long TermTaxonomyId { get; set; }

        [JsonProperty("taxonomy")]
        public string Taxonomy { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("parent")]
        public long Parent { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("cat_ID")]
        public long CatId { get; set; }

        [JsonProperty("category_count")]
        public long CategoryCount { get; set; }

        [JsonProperty("category_description")]
        public string CategoryDescription { get; set; }

        [JsonProperty("cat_name")]
        public string CatName { get; set; }

        [JsonProperty("category_nicename")]
        public string CategoryNicename { get; set; }

        [JsonProperty("category_parent")]
        public long CategoryParent { get; set; }
    }
}
