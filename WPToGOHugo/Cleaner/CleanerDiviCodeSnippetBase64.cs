using System;
using System.Text;
using System.Text.RegularExpressions;

namespace WPToGOHugo.Cleaner
{
    internal class CleanerDiviCodeSnippetBase64 : BaseCleanerDivi
    {

        private const string FORMAT_SECTION = "```";

        private const string TAG_CODE = "et_pb_dmb_code_snippet";
      
        public string Run(string value)
        {
          
            while (value.IndexOf(TAG_CODE) != -1)
            {
                value = base.Run(value);
                value = this.RemoveTagWithBase64(value, $"[{TAG_CODE}", $"[/{TAG_CODE}]", FORMAT_SECTION);
            }

            return value;
        }
    }
}