using System;
using System.IO;
using System.Net.Http;

namespace WPToGOHugo.TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Missing file name");
                return;
            }

            string source = args[0];
            string content = string.Empty;

            try
            {
                if (source.StartsWith(Helper.HTTP) || source.StartsWith(Helper.HTTPS))
                {
                    using (var client = new HttpClient())
                    {
                        var result = client.GetAsync(source).Result;
                        content = result.Content.ReadAsStringAsync().Result;
                    }
                }
                else
                {
                    if (File.Exists(source) == false)
                    {
                        Console.WriteLine("File is not valid");
                        return;
                    }

                    content = File.ReadAllText(source);
                }
            }
            catch
            {
                Console.WriteLine("Unable to read content!!!");
                return;
            }

            string json = MigrateWPContent.Run(content);

            SchemaToFileResultCollection results = Newtonsoft.Json.JsonConvert.DeserializeObject<SchemaToFileResultCollection>(json);

            foreach (var item in results)
            {
                File.WriteAllText(
                    Path.Combine(Helper.OutputFolder, item.FileName),
                    item.FileContent
                );
            }
        }
    }
}