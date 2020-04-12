using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WPToGOHugo.WPEntity;

namespace WPToGOHugo.JSONHelper
{
    internal class TagsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Tags) || t == typeof(Tags?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new Tags { Bool = boolValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<Tag>>(reader);
                    return new Tags { TagArray = arrayValue };
            }
            return new Tags { TagArray = new List<Tag>() };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public static readonly TagsConverter Singleton = new TagsConverter();
    }

}
