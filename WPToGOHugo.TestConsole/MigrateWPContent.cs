using System;
using System.Collections.Generic;
using System.Text;

namespace WPToGOHugo.TestConsole
{
    public class MigrateWPContent
    {

        public static void Run(string content)
        {
            Engine engine = new Engine(content);
            var jsonfile = engine.Run();
        }

    }
}