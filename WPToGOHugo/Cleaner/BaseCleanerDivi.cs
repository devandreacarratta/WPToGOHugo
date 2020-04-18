﻿using System;
using System.Collections.Generic;

namespace WPToGOHugo.Cleaner
{
    internal class BaseCleanerDivi : ICleaner
    {
        protected List<string> _tags = new List<string>();

        public BaseCleanerDivi()
        {
            _tags = new List<string>();
        }

        public virtual string Run(string value)
        {
            foreach (var tag in _tags)
            {
                value = RemoveTag(
                    value,
                    $"[{tag}",
                    $"[/{tag}]"
                );
            }
            return value;
        }

        protected string RemoveTag(string input, string startTag, string endTag)
        {
            bool bAgain = false;
            do
            {
                bAgain = false;
                int startTagPos = input.IndexOf(startTag, 0, StringComparison.CurrentCultureIgnoreCase);
                if (startTagPos < 0)
                    continue;
                int startTagClosePos = input.IndexOf("]", startTagPos + 1, StringComparison.CurrentCultureIgnoreCase);
                if (startTagClosePos <= startTagPos)
                    continue;

                input = input.Remove(startTagPos, startTagClosePos - startTagPos + 1);

                bAgain = true;
            } while (bAgain);

            input = input.Replace(endTag, string.Empty);

            return input;
        }

        protected string RemoveTagWithBase64(string input, string startTag, string endTag, string markdown)
        {
            int startTagPos = input.IndexOf(startTag, 0, StringComparison.CurrentCultureIgnoreCase);

            if (startTagPos < 0)
                return input;

            int startTagClosePos = input.IndexOf("]", startTagPos + 1, StringComparison.CurrentCultureIgnoreCase);

            if (startTagClosePos <= startTagPos)
                return input;

            string base64Text = input.Substring(startTagClosePos + 1, input.IndexOf(endTag) - startTagClosePos - 1);

            string decodeText = TextHelper.Base64Decode(base64Text);

            input = input.Remove(startTagPos, startTagClosePos - startTagPos + 1);

            decodeText = $"{Environment.NewLine}{markdown}{decodeText}{markdown}{Environment.NewLine}";
            input = input.Insert(startTagPos, decodeText);
            input = input.Replace(base64Text, string.Empty);

            input = input.Remove(input.IndexOf(endTag), endTag.Length);

            return input;
        }
    }
}