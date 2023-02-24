using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests
{
    internal class BaseTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void Quite()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }
    }
}
