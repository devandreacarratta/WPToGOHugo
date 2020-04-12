namespace WPToGOHugo
{
    /// <summary>
    /// Implemented method for clean text before import in md file (ex. shortcode via regex)
    /// </summary>
    internal class CleanerHelper
    {
        public CleanerHelper()
        {
        }

        public string DoAll(string value)
        {
            value = FakeCleanerMethod(value);

            return value;
        }

        public string FakeCleanerMethod(string value)
        {
            return value;
        }
    }
}