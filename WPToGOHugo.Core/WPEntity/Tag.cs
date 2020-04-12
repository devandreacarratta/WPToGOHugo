using Newtonsoft.Json;

namespace WPToGOHugo.Core.WPEntity
{
    internal class Tag
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
    }
}
