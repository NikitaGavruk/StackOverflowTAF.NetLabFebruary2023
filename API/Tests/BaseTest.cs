using API.APIUtils;
using AventStack.ExtentReports;
using Core.Logger;
using Core.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using static Core.Logger.Logger;

namespace API.Tests
{
    internal class BaseTest
    {
        protected static Client client;
        protected static Logger logger;
        protected static ExtentReports extentReporter = ExtentReporter.ConfigureExtentReporter();
        protected static ExtentTest testCase;
        protected static XML_Reader reader;

        //[OneTimeSetUp]
        //public void OneTimeSetup() {
        //    Environment.CurrentDirectory = $@"{Environment.CurrentDirectory}\..\..\..";
        //}

        [SetUp]
        public void Setup()
        {
            string[] dirs = Directory.GetFiles($@"{Environment.CurrentDirectory}\..\..\..", "Endpoints.xml",SearchOption.AllDirectories);
            //Console.WriteLine(Environment.CurrentDirectory);
            //Environment.CurrentDirectory = $@".\..\..\..";
            //Console.WriteLine(Environment.CurrentDirectory);
            testCase = extentReporter.CreateTest(TestContext.CurrentContext.Test.Name);
            testCase.Model.Name = TestContext.CurrentContext.Test.Name;
            logger = new Logger(GetType());
            logger.Info($"Test: [{TestContext.CurrentContext.Test.Name}] started");
            client = Client.Instance;
            reader = new XML_Reader(dirs[0]);
        }

        [TearDown]
        public void Quite()
        {
            TestStatus NUnit_status = TestContext.CurrentContext.Result.Outcome.Status;
            Status extentStatus = ExtentReporter.TestStatusConvert(TestContext.CurrentContext.Result.Outcome.Status);
            if (NUnit_status.Equals(TestStatus.Failed)) {
                logger.Error("Test returned an Error: ", TestContext.CurrentContext.Result.Message);
                testCase.Log(extentStatus,
                    "Test ended with status: " + TestContext.CurrentContext.Result.Outcome.Status.ToString() + ", Message: " + TestContext.CurrentContext.Result.Message);
            }
            else {
                logger.Info($"Test: [{TestContext.CurrentContext.Test.Name}] Ended With Status: " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
                testCase.Log(extentStatus,
                    "Test ended with status: " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
            }
            
            API.APIUtils.API.CloseRequest();
            Client.QuitClient();
            //Console.WriteLine(Environment.CurrentDirectory);
            //Environment.CurrentDirectory = $@"API\bin\debug";
            //Console.WriteLine(Environment.CurrentDirectory);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //Environment.CurrentDirectory = $@".\..\..\..";
            ExtentReporter.ExtentFlush(extentReporter, ExtentReporter.Projects.API);
        }

    }
}
