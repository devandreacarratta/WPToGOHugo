using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPToGOHugo.HugoEntity
{

    public class FileSchemaEntity
    {
        [JsonIgnore]
        public string FileName { get; set; }

        public string title { get; set; }
        public string content { get; set; }
        public string date { get; set; }

        public bool draft { get; set; }
        [JsonIgnore]
        public List<string> TagsList { get; set; } = new List<string>();
        [JsonIgnore]
        public List<string> CategoriesList { get; set; } = new List<string>();

        public string tags
        {
            get
            {
                string tagJoin = string.Join(',', TagsList);

                return $"[{tagJoin}]";
            }
        }

        public string categories
        {
            get
            {
                string catJoin = string.Join(',', CategoriesList);

                return $"[{catJoin}]";
            }
        }

        public string seo_metadesc { get; set; }
        public string seo_image { get; set; }
        public string seo_focuskw { get; set; }

    }
}