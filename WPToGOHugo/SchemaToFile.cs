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
            sb.AppendLine($"description: '{TextHelper.CleanBeforeMD(fileSchema.description)}'");
            sb.AppendLine($"author: '{TextHelper.CleanBeforeMD(fileSchema.author)}'");
            sb.AppendLine($"date: {TextHelper.CleanBeforeMD(fileSchema.date)}");
            sb.AppendLine($"image: '{TextHelper.CleanBeforeMD(fileSchema.image)}'");
            sb.AppendLine($"draft: {fileSchema.draft}");
            sb.AppendLine($"tags: [{fileSchema.tags}]");
            sb.AppendLine($"categories: [{fileSchema.categories}]");
            //sb.AppendLine($"seometadesc: '{TextHelper.CleanBeforeMD(fileSchema.description)}'");
            //sb.AppendLine($"seofocuskw: '{TextHelper.CleanBeforeMD(fileSchema.seo_focuskw)}'");
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