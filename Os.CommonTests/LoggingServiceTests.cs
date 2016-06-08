using Microsoft.VisualStudio.TestTools.UnitTesting;
using Os.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Os.Common.Tests
{
    [TestClass()]
    public class LoggingServiceTests
    {
        [TestMethod()]
        public void LogActionTest()
        {
            //Arrange
            var expected = "Action: Test";

            //Act
            var actual = LoggingService.LogAction("Test");

            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}