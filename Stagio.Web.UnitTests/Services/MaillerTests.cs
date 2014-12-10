using System;
using System.Security.Cryptography;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class MaillerTests
    {
        private IMailler mailler;

        [TestInitialize]
        public void test_initialize()
        {
            mailler = Mailler.Instance;
        }
        [TestMethod]
        public void mailler_should_return_true_when_email_is_send()
        {
            const String message = "Test message";
            const String subject = "Test";
            const String destination = "test@hotmail.com";

            var result = mailler.SendEmail(destination, subject, message);

            result.Should().BeTrue();
        }

        [TestMethod]
        public void mailler_should_return_false_when_invalid_destination_email()
        {
            const String message = "Test message";
            const String subject = "Test";
            const String destination = "invalid-email";

            var result = mailler.SendEmail(destination, subject, message);

            result.Should().BeFalse();
        }
    }
}
