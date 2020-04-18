using System.IO;

namespace WPToGOHugo.TestConsole
{
    public class DownloadPHPPage
    {
        public static string Run()
        {
            var page = WPToGOHugo.DownloadPHPExportPage.Get();
            string tempFileName = Path.GetTempFileName();
            File.WriteAllBytes(tempFileName, page);
            return tempFileName;
        }
    }
}