using System.Text;
using System.Text.RegularExpressions;

namespace WPToGOHugo.Cleaner
{
    internal class CleanerDiviCodeSnippetBase64 : BaseCleanerDivi
    {
        private const string FORMAT_SECTION = "```";

        private const string TAG_CODE = "et_pb_dmb_code_snippet";

        public override string Run(string value)
        {

            value = base.Run(value);

            if (value.IndexOf(TAG_CODE) == -1)
            {
                return value;
            }

            string pattern = @$"(?>^|\n|\[[^\]\n]*\]\n*)(?'content'[^\[]+)";

            var items = Regex.Matches(value, pattern, RegexOptions.IgnorePatternWhitespace);

            if (items == null || items.Count == 0)
            {
                return value;
            }

            StringBuilder sb = new StringBuilder();

            foreach (Match match in items)
            {
                string content = match.Groups["content"].Value;
                if (string.IsNullOrEmpty(content) == false)
                {
                    try
                    {
                        var decodeText = TextHelper.Base64Decode(content);

                        sb.AppendLine(FORMAT_SECTION);
                        sb.AppendLine(decodeText);
                        sb.AppendLine(FORMAT_SECTION);
                    }
                    catch
                    {
                        sb.AppendLine(content);
                    }
                }
            }

            string result = sb.ToString();

            return result;
        }
    }
}