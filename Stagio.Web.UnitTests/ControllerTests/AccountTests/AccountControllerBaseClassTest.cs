using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Controllers;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.ControllerTests.EnterpriseTests;

namespace Stagio.Web.UnitTests.ControllerTests.AccountTests
{
    public class AccountControllerBaseClassTest : AllControllersBaseClassTests
    {
        protected AccountController _accountController;
        protected IHttpContextService _httpContext;
        protected IAccountService _accountService;

        [TestInitialize]
        public void AccountControllerTestInit()
        {
            _httpContext = Substitute.For<IHttpContextService>();
            _accountService = Substitute.For<IAccountService>();
            _accountController = new AccountController(_httpContext, _accountService);
        }
    }
}
