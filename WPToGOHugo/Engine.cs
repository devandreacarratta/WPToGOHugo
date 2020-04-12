using System;
using System.Collections.Generic;
using System.Text;
using WPToGOHugo.HugoEntity;
using WPToGOHugo.WPEntity;

namespace WPToGOHugo
{
    public class Engine
    {
        private string _json = string.Empty;
        public Engine(string json)
        {
            _json = json;
        }

        public string Run()
        {
            var posts = Newtonsoft.Json.JsonConvert.DeserializeObject< PostCollection>(_json, JSONHelper.Converter.Settings);

            FileSchemaEntityCollection files = new FileSchemaEntityCollection();

            foreach (var item in posts)
            {
                files.Add(
                    PostConverter.Run(item)
                );
            }
               

            return string.Empty;
        }

        

    }
}
