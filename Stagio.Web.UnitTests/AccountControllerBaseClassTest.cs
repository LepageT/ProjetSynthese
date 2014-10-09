
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests
{
    public class AccountControllerBaseClassTest
    {
        private AccountController _accountController;
        private IHttpContextService _httpContext;
        private IAccountService _accountService;

        [TestInitialize]
        public void AccountControllerTestInit()
        {
            _httpContext = Substitute.For<IHttpContextService>();
            _accountService = Substitute.For<IAccountService>();
            _accountController = new AccountController(_httpContext, _accountService);
        }
    }
}
