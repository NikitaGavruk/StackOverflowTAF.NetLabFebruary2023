using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTeamProject.WebDriver
{
    internal class Configuration
    {
        public static string GetEnvironmentVar(string var, string defaultaVar)
        {
            string SourceCodeConfigeFile = $"{Assembly.GetExecutingAssembly().Location}.config";
            string OutputonfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            File.Copy(SourceCodeConfigeFile, OutputonfigFile, true);
            return ConfigurationManager.AppSettings[var] ?? defaultaVar;
        }

        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "30");
        public static string Browser => GetEnvironmentVar("Browser", "Chrome");
        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://stackoverflow.com");

    }
}
