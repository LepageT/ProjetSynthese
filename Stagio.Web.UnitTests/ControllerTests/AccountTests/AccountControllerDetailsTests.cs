using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.ControllerTests.AccountTests
{
    [TestClass]
    public class AccountControllerDetailsTests : AccountControllerBaseClassTests
    {
        [TestMethod]
        public void accountDetails_should_render_view_with_accountDetails()
        {
            var account = _fixture.Create<ApplicationUser>();
            httpContext.GetUserId().Returns(account.Id);
            accountRepository.GetById(account.Id).Returns(account);
            var result = accountController.Details(account.Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void accountDetails_should_render_httpNotFound_if_invalid_id()
        {
            var result = accountController.Details(999999999);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

    }
}
