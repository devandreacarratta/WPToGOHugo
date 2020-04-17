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


        public string Run(string value)
        {
          
            if(value.IndexOf(TAG_CODE) ==-1){
                return value;
            }

            value = base.Run(value);

            value = value.Trim();


            StringBuilder sb = new StringBuilder();


            string pattern = @$"(\[{TAG_TEXT}\s((.*?))\](?<pretextcontent>(.*?))\[\/{TAG_TEXT}\])|(\[{TAG_CODE}\s(.*?)\](?<code64>.*?)\[.*?\])";

            var items = Regex.Matches(value, pattern, RegexOptions.IgnorePatternWhitespace);

            if(items== null || items.Count==0){
                return value;
            }

            foreach (Match match in items)
            {
                string section = match.Groups["section"].Value;
                if (string.IsNullOrEmpty(section) == false)
                {
                    sb.AppendLine(section);
                }

                string pre = match.Groups["pretextcontent"].Value;
                if (string.IsNullOrEmpty(pre) == false)
                {
                    sb.AppendLine(pre);
                }

                string base64Code = match.Groups["code64"].Value;
                if (string.IsNullOrEmpty(base64Code) == false)
                {
                    sb.AppendLine(FORMAT_SECTION);
                    sb.AppendLine(
                        TextHelper.Base64Decode(base64Code)
                    );
                    sb.AppendLine(FORMAT_SECTION);
                }
            }

            value = sb.ToString();

            return value;
        }
    }
}