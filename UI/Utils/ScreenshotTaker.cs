using AutomationTeamProject.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.IO;
using System;
using System.Drawing;
using Core.Logger;
using Core.Exceptions;

namespace UI.Utils {

    internal static class ScreenshotTaker {

        private static Logger logger = new Logger(typeof(ScreenshotTaker));

        private static IWebDriver GetDriver() {
            return Browser.GetDriver();
        }

        private static void DeleteRepeatedFiles(string dir, string repeatFactor, int deleteFactor) {
            if (dir.Length < 1 || dir == null
               || repeatFactor.Length < 1 || repeatFactor == null
               || deleteFactor < 1)
                throw new ArgumentException();

            string[] files = Directory.GetFiles(dir);
            string[] filesToDelete = new string[files.Length];
            int count = 0;
            foreach (string item in files) {
                if (item.Contains(repeatFactor)) {
                    filesToDelete[count] = item;
                    count++;
                }
            }
            string currentDir = Environment.CurrentDirectory;
            if (count >= deleteFactor) {
                foreach (string item in filesToDelete) {
                    File.Delete(currentDir + "\\" + item);
                }
            }
        }

        public static string TakeScreenShot() {
            string saveDirectory;
            if (Environment.CurrentDirectory.EndsWith(@"bin\Debug"))
                saveDirectory = @"Screenshots";
            else
                saveDirectory = @"UI\bin\Dubug\Screenshots";

            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);
            else {
                try {
                    DeleteRepeatedFiles(saveDirectory, TestContext.CurrentContext.Test.Name, 5);
                }
                catch (Exception exe) {
                    logger.Error("Old Screenshots Were Not Deleted", exe.Message);
                }
            }

            string path = String.Format(saveDirectory + @"\{0}_{1}.{2}",
                    DateTime.UtcNow.ToString("dd-MM-yyyTHH-mm-ss"),
                    TestContext.CurrentContext.Test.Name,
                    ImageFormat.Jpeg.ToString().ToLower());

            try {
                Screenshot screen = ((ITakesScreenshot)GetDriver()).GetScreenshot();
                byte[] array = screen.AsByteArray;

                using (Image image = Image.FromStream(new MemoryStream(array, false))) {
                    image.Save(path);
                }
            }
            catch (Exception exe) {
                logger.Error("Screenshot Was Not Taken", exe.Message);
                throw new LoggerException("Screenshot Was Not Taken");
            }
            return path;
        }

    }

}