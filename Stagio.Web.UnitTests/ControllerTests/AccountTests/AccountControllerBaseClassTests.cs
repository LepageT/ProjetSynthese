using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.AccountTests
{
    [TestClass]
    public class AccountControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected AccountController accountController;
        protected IHttpContextService httpContext;
        protected IAccountService accountService;
        
        [TestInitialize]
        public void AccountControllerTestInit()
        {
            httpContext = Substitute.For<IHttpContextService>();
            accountService = Substitute.For<IAccountService>();
            accountController = new AccountController(httpContext, accountService);
        }
    }
}
