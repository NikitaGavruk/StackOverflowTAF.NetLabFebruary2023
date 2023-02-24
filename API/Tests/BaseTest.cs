﻿using API.APIUtils;
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
            logger.Info($"Test: [{TestContext.CurrentContext.Test.Name}] started");
            logger = new Logger(GetType());
            client = Client.Instance;
        }

        [TearDown]
        public void Quite()
        {
            TestStatus NUnit_status = TestContext.CurrentContext.Result.Outcome.Status;
            Status extentStatus = ExtentReporter.TestStatusConvert(TestContext.CurrentContext.Result.Outcome.Status);
            if (NUnit_status.Equals(TestStatus.Failed)) {
                logger.Error("Test returned an Error: ", TestContext.CurrentContext.Result.Message);
            }
            else {
                logger.Info($"Test: [{TestContext.CurrentContext.Test.Name}] Ended With Status: " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
            }
            testCase.Log(extentStatus,
                    "Test ended with status: " + TestContext.CurrentContext.Result.Outcome.Status.ToString()+" Message: "+ TestContext.CurrentContext.Result.Message);
            API.APIUtils.API.CloseRequest();
            Client.QuitClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReporter.ExtentFlush(extentReporter);
        }

    }
}
