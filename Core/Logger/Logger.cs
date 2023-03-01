using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using log4net;
using NUnit.Framework.Interfaces;
using System;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Core.Logger {

    public class Logger {

        private readonly ILog log;

        public Logger(Type type) {
            log = LogManager.GetLogger(type);
        }

        public void Debug(string methodName) {
            log.Debug(methodName);
        }

        public void Info(string message) {
            log.Info(message);
        }

        public void Error(string message, string exe) {
            log.Error(message + " outcome:" + exe);
        }

        public static class ExtentReporter {

            public enum Projects { UI, API, BDD }

            public static Status TestStatusConvert(TestStatus status) {
                Status testStatus;
                switch (status) {
                    case TestStatus.Passed:
                        testStatus = Status.Pass;
                        break;
                    case TestStatus.Failed:
                        testStatus = Status.Fail;
                        break;
                    case TestStatus.Skipped:
                        testStatus = Status.Skip;
                        break;
                    case TestStatus.Warning:
                        testStatus = Status.Warning;
                        break;
                    default:
                        testStatus = Status.Fail;
                        break;
                }
                return testStatus;
            }

            public static ExtentReports ConfigureExtentReporter(Projects projectName) {
                string path;
                if (Environment.CurrentDirectory.EndsWith(@"bin\Debug")) {
                    path = String.Format(@"Reports" + @"\{0}_TestRun",
                    DateTime.UtcNow.ToString("dd-MM-yyyTHH-mm-ss"));
                }
                else {
                    path = String.Format($@"{projectName}\bin\Debug\Reports" + @"\{0}_TestRun",
                    DateTime.UtcNow.ToString("dd-MM-yyyTHH-mm-ss"));
                }

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                try {
                    DeleteReports(6, projectName);
                }
                catch (Exception exe) {
                    Logger logger = new Logger(typeof(ExtentReporter));
                    logger.Error("Old Reports Directories Were Not Deleted", exe.Message);
                }

                ExtentHtmlReporter htmlReporter=null;
                if (Environment.CurrentDirectory.EndsWith(@"bin\Debug")) {
                    htmlReporter = new ExtentHtmlReporter(path + @"\index.html");
                }
                else {
                    htmlReporter = new ExtentHtmlReporter($@"{projectName}\bin\debug\"+path + @"\index.html");
                }

                htmlReporter.Config.DocumentTitle = "Reports";
                htmlReporter.Config.ReportName = "Reporting For StackOverFlow Tests";
                ExtentReports extentReporter = new ExtentReports();
                extentReporter.AttachReporter(htmlReporter);
                return extentReporter;
            }

            public static bool DeleteReports(int deleteFactor, Projects projectName) {
                if (deleteFactor < 1)
                    throw new ArgumentException("The Count of Folders to Delete Has to Be at Least One");

                string[] reportDirectories;
                if (Environment.CurrentDirectory.EndsWith(@"bin\Debug")) {
                    reportDirectories = Directory.GetDirectories($@"{Environment.CurrentDirectory}\Reports");
                }
                else {
                    reportDirectories = Directory.GetDirectories($@"{projectName}\bin\Debug\Reports");
                }

                try {
                    if (reportDirectories.Length >= deleteFactor) {
                        foreach (var item in reportDirectories) {
                            Directory.Delete(item, true);
                        }
                    }
                }
                catch (Exception exe) {
                    Logger logger = new Logger(typeof(ExtentReporter));
                    logger.Error("The Old Reports Directories Were Not Deleted", exe.ToString());
                    return false;
                }
                return true;
            }

            public static void ExtentFlush(ExtentReports reporter) {
                reporter.Flush();
            }

        }

    }

}