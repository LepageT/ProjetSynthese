
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Web.Controllers;
using Stagio.Web.Mappers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests
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
