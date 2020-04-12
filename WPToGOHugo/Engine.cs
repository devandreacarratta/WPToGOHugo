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
            var posts = Newtonsoft.Json.JsonConvert.DeserializeObject<PostCollection>(_json, JSONHelper.Converter.Settings);

            FileSchemaEntityCollection schemaEntities = FillFileSchemaEntityCollection(posts);
            SchemaToFileResultCollection files = FillSchemaToFileResultCollection(schemaEntities);

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(files);
            return result;
        }

        private static SchemaToFileResultCollection FillSchemaToFileResultCollection(FileSchemaEntityCollection schemaEntities)
        {
            var files = new SchemaToFileResultCollection();
            foreach (var item in schemaEntities)
            {
                files.Add(
                        SchemaToFile.Run(item)
                    );
            }

            return files;
        }

        private FileSchemaEntityCollection FillFileSchemaEntityCollection(PostCollection posts)
        {
            FileSchemaEntityCollection schemaEntities = new FileSchemaEntityCollection();

            CleanerHelper cleaner = new CleanerHelper();

            foreach (var item in posts)
            {
                item.content = cleaner.FakeCleanerMethod(item.content);

                schemaEntities.Add(
                    PostConverter.Run(item)
                );
            }

            return schemaEntities;
        }
    }
}