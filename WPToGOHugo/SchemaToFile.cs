using System.Text;
using WPToGOHugo.HugoEntity;

namespace WPToGOHugo
{

    internal class SchemaToFile
    {

        private const string SPLIT_ROW = "---";

        public static SchemaToFileResult Run(FileSchemaEntity fileSchema)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(SPLIT_ROW);
            sb.AppendLine($"title: '{TextHelper.CleanBeforeMD(fileSchema.title)}'");
            sb.AppendLine($"description: '{TextHelper.CleanBeforeMD(fileSchema.title)}'");
            sb.AppendLine($"author: '{TextHelper.CleanBeforeMD(fileSchema.author)}'");
            sb.AppendLine($"date: {TextHelper.CleanBeforeMD(fileSchema.date)}");
            sb.AppendLine("draft: false");
            sb.AppendLine($"tags: [{fileSchema.tags}]");
            sb.AppendLine($"categories: [{fileSchema.categories}]");
            sb.AppendLine($"seometadesc: '{TextHelper.CleanBeforeMD(fileSchema.seo_metadesc)}'");
            sb.AppendLine($"seofocuskw: '{TextHelper.CleanBeforeMD(fileSchema.seo_focuskw)}'");
            sb.AppendLine($"seoimage: '{TextHelper.CleanBeforeMD(fileSchema.seo_image)}'");
            sb.AppendLine(SPLIT_ROW);
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