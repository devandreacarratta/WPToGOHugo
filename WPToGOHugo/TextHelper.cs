﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WPToGOHugo
{
    internal class TextHelper
    {
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string CleanBeforeMD(string input)
        {
            SortedDictionary<string, string> items = new SortedDictionary<string, string>();

            foreach (var item in items)
            {
                input = input.Replace(item.Key, item.Value);
            }

            input = WebUtility.HtmlEncode(input);

            return input;
        }

        private static SortedDictionary<string, string> _cacheTagsAndCategories = new SortedDictionary<string, string>();

        public static string CleanTagsAndCategories(string input)
        {
            string result = string.Empty;

            if (_cacheTagsAndCategories.TryGetValue(input, out result) == false)
            {
                result = SlugHelper.Generate(input);

                _cacheTagsAndCategories.Add(input, result);
            }

            return result;
        }

        public static string HtmlDecode(string input)
        {
            return WebUtility.HtmlDecode(input);
        }
    }
}