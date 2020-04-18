using System;
using System.Text;
using System.Text.RegularExpressions;

namespace WPToGOHugo.Cleaner
{
    internal class CleanerDiviCodeSnippetBase64 : BaseCleanerDivi
    {

        private const string FORMAT_SECTION = "```";

        private const string TAG_CODE = "et_pb_dmb_code_snippet";
        private const string TAG_TEXT = "et_pb_dmb_code_snippet";

        //string pattern = @"(\[et_pb_text\s((.*?))\](?<pretextcontent>(.*?))\[\/et_pb_text\])|(\[et_pb_dmb_code_snippet\s(.*?)\](?<code64>.*?)\[.*?\])";


        public override string Run(string value)
        {

            if (value.IndexOf(TAG_CODE) == -1)
            {
                return value;
            }

            value = base.Run(value);

            value = value.Trim();


            StringBuilder sb = new StringBuilder();


            string pattern = @$"(?>^|\n|\[[^\]\n]*\]\n*)(?'content'[^\[]+)";

            var items = Regex.Matches(value, pattern, RegexOptions.IgnorePatternWhitespace);

            if (items == null || items.Count == 0)
            {
                return value;
            }

            foreach (Match match in items)
            {
                string content = match.Groups["content"].Value;
                if (string.IsNullOrEmpty(content) == false)
                {

                    try{
                        var decodeText=TextHelper.Base64Decode(content);

                        sb.AppendLine(FORMAT_SECTION);
                        sb.AppendLine(decodeText);
                        sb.AppendLine(FORMAT_SECTION);


                    }
                    catch{
                        sb.AppendLine(content);
                    }

                }

               
            }

            value = sb.ToString();

            return value;
        }
    }
}