namespace AutomationTeamProject.WebDriver
{
    public class Configuration
    {

        public static string GetEnvironmentVar(string var, string defaultaVar)
        {
            return defaultaVar;
        }

        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "30");

        public static string Browser => GetEnvironmentVar("Browser", "RemoteChrome");

        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://stackoverflow.com");

    }
}
