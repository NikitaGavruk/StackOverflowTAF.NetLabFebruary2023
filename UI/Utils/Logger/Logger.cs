using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using log4net;
using NUnit.Framework;
using System;
using System.Drawing.Imaging;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace UI.Utils.Logger {

    public class Logger {

        private readonly ILog log;

        public Logger(Type type) {
            log= LogManager.GetLogger(type);
        }

        public void Debug(string methodName) {
            log.Debug(methodName);
        }

        public void Info(string message) {
            log.Info(message);
        }

        public void Error(string message, string exe) {
            log.Error(message+" outcome:"+exe);
        }

        public static ExtentReports ConfigureHTMLReport() {
            string saveDirectory = @"UI\bin\Debug\HTML_Reports";
            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);
            string path = String.Format(saveDirectory + @"\{0}_{1}.html",
                DateTime.UtcNow.ToString("dd-MM-yyyTHH-mm-ss"),
                TestContext.CurrentContext.Test.Name);

            var htmlReporter = new ExtentHtmlReporter(saveDirectory+ path);

            ExtentReports _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
            return _extent;
        }

    }

}