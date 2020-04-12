using Newtonsoft.Json;
using System.Collections.Generic;

namespace WPToGOHugo.WPEntity
{
    internal struct Tags
    {
        public bool? Bool;
        public List<Tag> TagArray;

        public static implicit operator Tags(bool Bool) => new Tags { Bool = Bool };
        public static implicit operator Tags(List<Tag> TagArray) => new Tags { TagArray = TagArray };
    }

    internal class Tag
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
    }
}
