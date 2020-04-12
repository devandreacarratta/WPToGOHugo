using System;
using System.IO;
using System.Net.Http;

namespace WPToGOHugo.TestConsole
{
    class Program
    {
        static void Main(string[] args)
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
                        var result =  client.GetAsync(source).Result;
                        content =  result.Content.ReadAsStringAsync().Result;
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


            MigrateWPContent.Run(content);




        }
    }
}
