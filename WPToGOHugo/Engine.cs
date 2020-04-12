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

            FileSchemaEntityCollection schemaEntities = new FileSchemaEntityCollection();

            foreach (var item in posts)
            {
                schemaEntities.Add(
                    PostConverter.Run(item)
                );
            }

            var files = new SchemaToFileResultCollection();
            foreach (var item in schemaEntities)
            {
                files.Add(
                        SchemaToFile.Run(item)
                    ) ;
            }

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(files);
            return result;
        }

        

    }
}
