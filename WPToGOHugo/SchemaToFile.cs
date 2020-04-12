using System.Collections.Generic;
using System.Text;
using WPToGOHugo.HugoEntity;

namespace WPToGOHugo
{
    public class SchemaToFileResultCollection : List<SchemaToFileResult>
    {
    }

    public class SchemaToFileResult
    {
        public string FileName { get; set; }
        public string FileContent { get; set; }
    }

    internal class SchemaToFile
    {
        public static SchemaToFileResult Run(FileSchemaEntity fileSchema)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---");
            sb.AppendLine($"title: '{fileSchema.title}'");
            sb.AppendLine($"date: {fileSchema.date}");
            sb.AppendLine("draft: false");
            sb.AppendLine($"tags: [{fileSchema.tags}]");
            sb.AppendLine($"categories: [{fileSchema.categories}]");
            sb.AppendLine($"seometadesc: [{fileSchema.seo_metadesc}]");
            sb.AppendLine($"seofocuskw: [{fileSchema.seo_focuskw}]");
            sb.AppendLine($"seoimage: [{fileSchema.seo_image}]");
            sb.AppendLine("---");
            sb.AppendLine($"{fileSchema.content}");
            sb.AppendLine("");

            SchemaToFileResult result = new SchemaToFileResult()
            {
                FileContent = sb.ToString(),
                FileName = $"{fileSchema.FileName}.md"
            };

            return result;
        }
    }
}