using System.IO;
using System.Linq;
using System.Reflection;

namespace WPToGOHugo
{
    public class DownloadPHPExportPage
    {
        public static byte[] Get()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resourceName = Assembly.GetExecutingAssembly()
              .GetManifestResourceNames()
              .Where(name => name.Contains("WPToGOHugoExport"))
              .First();

            Stream stream = assembly.GetManifestResourceStream(resourceName);

            byte[] data = new byte[stream.Length];

            stream.Read(data, 0, (int)stream.Length);

            return data;
        }
    }
}