using System.Configuration;
using System.IO;
using System.Reflection;

namespace AutomationTeamProject.WebDriver
{
    public class Configuration
    {

        //app.config data exrtractor method
        public static string GetEnvironmentVar(string var, string defaultaVar)
        {
            string SourceCodeConfigeFile = $"{Assembly.GetExecutingAssembly().Location}.config";
            string OutputonfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            File.Copy(SourceCodeConfigeFile, OutputonfigFile, true);
            return ConfigurationManager.AppSettings[var] ?? defaultaVar;
        }

        //app.config Timeout extraction
        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "30");

        //app.config Browser extraction
        public static string Browser => GetEnvironmentVar("Browser", "Chrome");

        //app.config starting Url  extraction
        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://stackoverflow.com");

    }
}
