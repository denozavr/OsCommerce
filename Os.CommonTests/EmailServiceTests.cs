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
    public class EmailServiceTests
    {
        [TestMethod()]
        public void SendMessageTest()
        {
            var email = new EmailService();
            var expected = "Message sent: Test";

            // Act
            var actual = email.SendMessage("Test",
                "This is a test", "test@test.com");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}