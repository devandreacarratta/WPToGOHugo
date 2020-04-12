using System;
using System.Collections.Generic;
using System.Text;

namespace WPToGOHugo.TestConsole
{
    public class MigrateWPContent
    {

        public static string Run(string content)
        {
            Engine engine = new Engine(content);
            return engine.Run();
        }

    }
}