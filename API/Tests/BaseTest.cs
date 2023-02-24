using API.APIUtils;
using AventStack.ExtentReports;
using Core.Logger;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using static Core.Logger.Logger;

namespace API.Tests
{
    internal class BaseTest
    {
        protected static Client client;
        protected static Logger logger;
        protected static ExtentReports extentReporter = ExtentReporter.ConfigureExtentReporter();
        protected static ExtentTest testCase;

        [SetUp]
        public void Setup()
        {
            testCase = extentReporter.CreateTest(TestContext.CurrentContext.Test.Name);
            testCase.Model.Name = TestContext.CurrentContext.Test.Name;
            logger = new Logger(GetType());
            client = Client.Instance;
        }

        [TearDown]
        public void Quite()
        {

            TestStatus NUnit_status = TestContext.CurrentContext.Result.Outcome.Status;
            Status extentStatus = ExtentReporter.TestStatusConvert(TestContext.CurrentContext.Result.Outcome.Status);
            Client.QuitClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReporter.ExtentFlush(extentReporter);
        }
    }
}
