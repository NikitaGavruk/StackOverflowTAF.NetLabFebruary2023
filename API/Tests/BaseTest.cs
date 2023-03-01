﻿using API.APIUtils;
using AventStack.ExtentReports;
using Core.Logger;
using Core.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
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
            Environment.CurrentDirectory = $@"{Environment.CurrentDirectory}\..\..\..";
            testCase = extentReporter.CreateTest(TestContext.CurrentContext.Test.Name);
            testCase.Model.Name = TestContext.CurrentContext.Test.Name;
            logger = new Logger(GetType());
            logger.Info($"Test: [{TestContext.CurrentContext.Test.Name}] started");
            logger = new Logger(GetType());
            client = Client.Instance;
            reader = new XML_Reader($@"API\TestData\Endpoints.xml");
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
            Environment.CurrentDirectory = $@"{Environment.CurrentDirectory}\API\bin\debug";
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReporter.ExtentFlush(extentReporter, ExtentReporter.Projects.API);
        }

    }
}
