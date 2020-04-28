using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WPToGOHugo.Cleaner
{
    internal class CleanerDiviCodeSnippetBase64 : ICleaner
    {
        private const string FORMAT_SECTION = "```";
        private const string TAG_CODE = "et_pb_dmb_code_snippet";
        private const string ATTRIBUTE_TITLE = "title";
        private const string ATTRIBUTE_LANGUAGE = "language";

        private SortedDictionary<string, string> _tagsToRemove = null;
        private SortedDictionary<string, string> TagsToRemove
        {
            get
            {
                if(_tagsToRemove == null)
                {
                    _tagsToRemove = new SortedDictionary<string, string>();
                    _tagsToRemove.Add("<p>", "</p>");
                }
                return _tagsToRemove;
            }
        }
        private SortedDictionary<string, string> _shortCodeToRemove = null;
        private SortedDictionary<string, string> ShortCodeToRemove
        {
            get
            {
                if (_shortCodeToRemove == null)
                {
                    _shortCodeToRemove = new SortedDictionary<string, string>();
                    _shortCodeToRemove.Add("[et_pb_dmb_code_snippet]","[/et_pb_dmb_code_snippet]");
                }
                return _shortCodeToRemove;
            }
        }

        public CleanerDiviCodeSnippetBase64()
        {
        }

        

        public string Run(string value)
        {
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

                    foreach (var item in TagsToRemove)
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

                        sb.AppendLine(string.Empty);
                        sb.AppendLine(FORMAT_SECTION);
                        sb.AppendLine(string.Empty);
                        sb.AppendLine(decodeText);
                        sb.AppendLine(string.Empty);
                        sb.AppendLine(FORMAT_SECTION);
                        sb.AppendLine(string.Empty);
                    }
                    catch
                    {
                        // It wasn't a base64 text --> it's a free text

                        string matchValue = match.Value;

                        foreach (var item in ShortCodeToRemove)
                        {
                            if (matchValue.Contains(item.Key))
                            {
                                matchValue = matchValue.Replace(item.Key, string.Empty);
                            }

                            if (matchValue.Contains(item.Value))
                            {
                                matchValue = matchValue.Replace(item.Value, string.Empty);
                            }
                        }

                        matchValue = matchValue.Trim();

                        sb.AppendLine(matchValue);
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