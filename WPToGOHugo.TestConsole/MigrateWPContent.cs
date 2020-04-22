namespace WPToGOHugo.TestConsole
{
    public class MigrateWPContent
    {
        public static string Run(string content)
        {
            Engine engine = new Engine(content)
            {
                RunCleanerDivi = true,
                RunCleanerDiviCodeSnippetBase64 = true,
            };
            return engine.Run();
        }
    }
}