using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.AccountTests
{
    [TestClass]
    public class AccountControllerLoginTests : AccountControllerBaseClassTests
    {
        [TestMethod]
        public void login_should_render_default_view()
        {    
            var result = accountController.Login() as ViewResult;
            var viewName = result.ViewName;

            viewName.Should().Be("");
        }

        [TestMethod]
        public void login_post_should_render_default_view_when_user_is_not_valid()
        {
            var loginViewModel = _fixture.Create<ViewModels.Account.Login>();
            var invalidUser = new MayBe<ApplicationUser>();
            accountService.ValidateUser(loginViewModel.Username, loginViewModel.Password).Returns(invalidUser);
   
            var result = accountController.Login(loginViewModel) as ViewResult;
            var viewName = result.ViewName;

            viewName.Should().Be("");
        }

        [TestMethod]
        public void login_post_should_render_view_with_error_if_model_is_not_valid()
        {
            var loginViewModel = _fixture.Create<ViewModels.Account.Login>();
            accountController.ModelState.AddModelError("Error", "Error");
   
            var result = accountController.Login(loginViewModel) as ViewResult;
            var viewName = result.ViewName;

            viewName.Should().Be("");
        }


        [TestMethod]
        public void login_should_redirect_to_home_index_when_user_is_valid()
        {
            var user = _fixture.Create<ApplicationUser>();
            var loginViewModel = new ViewModels.Account.Login()
            {
                Username = user.UserName,
                Password = user.Password
            };
            var valideUser = new MayBe<ApplicationUser>(user);
            accountService.ValidateUser(loginViewModel.Username, loginViewModel.Password).Returns(valideUser);
            accountService.isCoordonator(user).Returns(true);
            accountService.isBetweenAccesibleDates().Returns(true);

            var routeResult = accountController.Login(loginViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);

        }
        [TestMethod]
        public void login_should_authentificate_user_when_user_is_valid()
        {
            var user = _fixture.Create<ApplicationUser>();
            user.Roles = new List<UserRole>()
            {
                new UserRole() {RoleName = RoleName.Coordinator}
            };
            var loginViewModel = new ViewModels.Account.Login()
            {
                Username = user.UserName,
                Password = user.Password
                
            };
            var valideUser = new MayBe<ApplicationUser>(user);
            accountService.ValidateUser(loginViewModel.Username, loginViewModel.Password).Returns(valideUser);
            accountService.isCoordonator(user).Returns(true);
            accountService.isBetweenAccesibleDates().Returns(true);

            accountController.Login(loginViewModel);

            httpContext.Received().AuthenticationSignIn(Arg.Any<ClaimsIdentity>());

        }

        [TestMethod]
        public void logout_should_logout_an_authentificated_user()
        {
            var user = _fixture.Create<ApplicationUser>();
            user.Roles = new List<UserRole>()
            {
                new UserRole() {RoleName = RoleName.Coordinator}
            };
            var loginViewModel = new ViewModels.Account.Login()
            {
                Username = user.UserName,
                Password = user.Password

            };
            var valideUser = new MayBe<ApplicationUser>(user);
            accountService.ValidateUser(loginViewModel.Username, loginViewModel.Password).Returns(valideUser);
   
            accountController.Login(loginViewModel);
            accountController.Logout();

            httpContext.Received().AuthenticationSignOut();

        }
    }
}
