using Html2Markdown;

namespace WPToGOHugo
{
    public class MarkdownConverter
    {
        private static Converter _converter = new Converter();

        public static string Run(string html)
        {
            string result = _converter.Convert(html);
            return result;
        }
    }
}