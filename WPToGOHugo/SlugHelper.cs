using Sluggy;
using System.Collections.Generic;
using System.Linq;

namespace WPToGOHugo
{
    public class SlugHelper
    {

        private static List<string> _keywords = null;
        private static List<string> Keywords
        {
            get
            {

                if (_keywords == null)
                {

                    List<int> code = new List<int>();
                    code.AddRange(Enumerable.Range(32, 47 - 32));
                    code.AddRange(Enumerable.Range(58, 64 - 58));
                    code.AddRange(Enumerable.Range(91, 96 - 91));
                    code.AddRange(Enumerable.Range(123, 126 - 123));

                    _keywords = code
                        .Select(x => ((char)x).ToString())
                        .ToList();


                }

                return _keywords;

            }
        }

        public static string Generate(string value)
        {

            foreach (var item in Keywords)
            {
                if (value.StartsWith(item))
                {
                    value = value.Substring(1);
                }
                value = value.Replace(item, "-");
            }

            return value.ToSlug();
        }




    }
}
