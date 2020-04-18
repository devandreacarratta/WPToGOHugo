using WPToGOHugo.Cleaner;
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

        public bool RunCleanerDiviCodeSnippetBase64 { get; set; } = false;

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

            CleanerDiviCodeSnippetBase64 cleanerBase64 = (RunCleanerDiviCodeSnippetBase64 ? new CleanerDiviCodeSnippetBase64() : null);

            foreach (var item in posts)
            {
                item.content = MarkdownConverter.Run(item.content);

                if (RunCleanerDiviCodeSnippetBase64)
                {
                    item.content = cleanerBase64.Run(item.content);
                }

                schemaEntities.Add(
                    PostConverter.Run(item)
                );
            }

            return schemaEntities;
        }
    }
}