using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WPToGOHugo.TestConsole
{
    internal  class Helper
    {

        public const string HTTP = "http";
        public const string HTTPS = "https";

        private static string _assemblyDirectory = string.Empty;
        public static string AssemblyDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_assemblyDirectory))
                {
                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    UriBuilder uri = new UriBuilder(codeBase);
                    string path = Uri.UnescapeDataString(uri.Path);
                    _assemblyDirectory= Path.GetDirectoryName(path);
                }
                return _assemblyDirectory;
            }
        }


        private static string _outputFolder = string.Empty;
        public static string OutputFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_outputFolder))
                {
                    _outputFolder = Path.Combine(AssemblyDirectory, "Output");
                    if (Directory.Exists(_outputFolder) == false)
                    {
                        Directory.CreateDirectory(_outputFolder);
                    }
                }
                return _outputFolder;
            }
        }

    }
}
