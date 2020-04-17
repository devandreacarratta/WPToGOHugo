using System.Text.RegularExpressions;

namespace WPToGOHugo.Cleaner
{
    internal class BaseCleanerDivi : ICleaner
    {
        public virtual string Run(string value)
        {
            return value;
        }
    }
}