using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WPToGOHugo.Cleaner
{

    internal class CleanerDiviCodeSnippetBase64 : ICleaner
    {
        public string Run(string value)
        {

            value = value.Trim();

                        StringBuilder sb = new StringBuilder();


            string pattern = @"(\[et_pb_text\s((.*?))\](?<pretextcontent>(.*?))\[\/et_pb_text\])|(\[et_pb_dmb_code_snippet\s(.*?)\](?<code64>.*?)\[.*?\])";

            var items = Regex.Matches(value, pattern, RegexOptions.Multiline);

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
                    sb.AppendLine(
                        TextHelper.Base64Decode(base64Code)
                    );
                }


            }
            
            return sb.ToString();

        }
    }
}
