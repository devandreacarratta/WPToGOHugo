namespace WPToGOHugo
{
    public class SchemaToFileResult
    {
        public string PostYYYY { get; set; }
        public string PostMM { get; set; }
        public string PostDD { get; set; }
        public string PostLanguage { get; set; }
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public string FileContentExtension { get; set; } = ".md";
    }
}