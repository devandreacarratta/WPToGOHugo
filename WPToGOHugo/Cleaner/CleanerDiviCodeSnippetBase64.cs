using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WPToGOHugo.Cleaner
{
    internal class CleanerDiviCodeSnippetBase64 : BaseCleanerDivi
    {
        private const string FORMAT_SECTION = "```";
        private const string TAG_CODE = "et_pb_dmb_code_snippet";
        private const string ATTRIBUTE_TITLE = "title";
        private const string ATTRIBUTE_LANGUAGE = "language";

        SortedDictionary<string, string> _tagsToRemove = null;

        public CleanerDiviCodeSnippetBase64() : base()
        {
            _tagsToRemove = new SortedDictionary<string, string>();
            _tagsToRemove.Add("<p>", "</p>");
        }

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
                if ((string.IsNullOrEmpty(content) == false) &&
                    (string.IsNullOrEmpty(content.Trim()) == false))
                {

                    var contentClean = content.Trim();

                    foreach (var item in _tagsToRemove)
                    {
                        if (contentClean.StartsWith(item.Key) && contentClean.EndsWith(item.Value))
                        {
                            contentClean = contentClean
                                .Substring(0, contentClean.Length - item.Value.Length)
                                .Substring(item.Key.Length);
                        }
                    }

                    try
                    {
                        var decodeText = TextHelper.Base64Decode(contentClean);

                        // It was a base64 text --> it's my code!

                        var snippet = match.Value;
                        
                        string title = GetAttributeFromSnippet(snippet, ATTRIBUTE_TITLE);
                        string language = GetAttributeFromSnippet(snippet, ATTRIBUTE_LANGUAGE);

                        if (string.IsNullOrEmpty(title) == false)
                        {

                            sb.AppendLine($"*{title}*");
                        }

                        if (string.IsNullOrEmpty(language) == false)
                        {

                            sb.Append($"({language})");
                        }
                        


                        sb.AppendLine(FORMAT_SECTION);                        
                        sb.AppendLine(decodeText);
                        sb.AppendLine(FORMAT_SECTION);
                    }
                    catch
                    {
                        // It wasn't a base64 text --> it's a free text
                        sb.AppendLine(content);
                    }
                }
            }

            string result = sb.ToString();

            return result;
        }

        private string GetAttributeFromSnippet(string snippet, string attribute)
        {
            if (snippet.Contains(attribute) == false)
            {
                return null;
            }

            int start = snippet.IndexOf(attribute) + attribute.Length + "=\"".Length;
            string snippetSubset = snippet.Substring(start);
            string result = snippetSubset.Substring(0, snippetSubset.IndexOf("\""));

            return result;
        }
    }
}