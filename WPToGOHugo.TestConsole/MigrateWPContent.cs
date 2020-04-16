namespace WPToGOHugo.TestConsole
{
    public class MigrateWPContent
    {
        public static string Run(string content)
        {
            Engine engine = new Engine(content)
            {
                RunCleanerDiviCodeSnippetBase64 = false,
            };
            return engine.Run();
        }
    }
}