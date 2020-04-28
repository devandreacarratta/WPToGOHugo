using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace WPToGOHugo.HugoEntity
{
    public class FileSchemaEntity
    {
        [JsonIgnore]
        public string FileName { get; set; }

        public string author { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string date { get; set; }

        public bool draft { get; set; }

        public string slug { get; set; }

        [JsonIgnore]
        public List<string> TagsList { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> CategoriesList { get; set; } = new List<string>();

        public string tags
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (TagsList != null && TagsList.Count > 0)
                {
                    foreach (var item in TagsList)
                    {
                        string tag = TextHelper.CleanTagsAndCategories(item);
                        sb.Append($"'{TextHelper.CleanBeforeMD(item)}',");
                    }
                    sb.Length -= 1;
                }

                return sb.ToString();
            }
        }

        public string categories
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (CategoriesList != null && CategoriesList.Count > 0)
                {
                    foreach (var item in CategoriesList)
                    {
                        string category = TextHelper.CleanTagsAndCategories(item);
                        sb.Append($"'{TextHelper.CleanBeforeMD(category)}',");
                    }
                    sb.Length -= 1;
                }

                return sb.ToString();
            }
        }

        public string description { get; set; }
        public string image { get; set; }
        public string seo_focuskw { get; set; }
    }
}