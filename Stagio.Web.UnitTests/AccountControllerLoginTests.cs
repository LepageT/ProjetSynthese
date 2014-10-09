using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;


namespace Stagio.Web.UnitTests
{
    [TestClass]
    public class AccountControllerLoginTests : AccountControllerBaseClassTest
    {
        [TestMethod]
        public void login_should_render_default_view()
        {
            //Action    
            var result = _accountController.Login() as ViewResult;
            var viewName = result.ViewName;

            //Assert
            viewName.Should().Be("");
        }

        [TestMethod]
        public void login_post_should_render_default_view_when_user_is_not_valid()
        {
            //Arrange
            var loginViewModel = _fixture.Create<ViewModels.Account.Login>();
            var invalidUser = new MayBe<ApplicationUser>();
            _accountService.ValidateUser(loginViewModel.Username, loginViewModel.Password).Returns(invalidUser);

            //Action    
            var result = _accountController.Login(loginViewModel) as ViewResult;
            var viewName = result.ViewName;

            //Assert
            viewName.Should().Be("");
        }

        [TestMethod]
        public void login_post_should_render_view_with_error_if_model_is_not_valid()
        {
            //Arrange
            var loginViewModel = _fixture.Create<ViewModels.Account.Login>();
            _accountController.ModelState.AddModelError("Error", "Error");
            //Action    
            var result = _accountController.Login(loginViewModel) as ViewResult;
            var viewName = result.ViewName;

            //Assert
            viewName.Should().Be("");
        }


        [TestMethod]
        public void login_should_redirect_to_home_index_when_user_is_valid()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            var loginViewModel = new ViewModels.Account.Login()
            {
                Username = user.UserName,
                Password = user.Password
            };

            var valideUser = new MayBe<ApplicationUser>(user);
            _accountService.ValidateUser(loginViewModel.Username, loginViewModel.Password).Returns(valideUser);

            //Action    
            var routeResult = _accountController.Login(loginViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);

        }
        [TestMethod]
        public void login_should_authentificate_user_when_user_is_valid()
        {
            //Arrange
            var user = _fixture.Create<ApplicationUser>();
            user.Roles = new List<UserRole>()
            {
                new UserRole() {RoleName = RoleName.Coordonnateur}
            };
            var loginViewModel = new ViewModels.Account.Login()
            {
                Username = user.UserName,
                Password = user.Password
                
            };

            var valideUser = new MayBe<ApplicationUser>(user);
            _accountService.ValidateUser(loginViewModel.Username, loginViewModel.Password).Returns(valideUser);

            //Action    
            _accountController.Login(loginViewModel);


            //Assert
            _httpContext.Received().AuthenticationSignIn(Arg.Any<ClaimsIdentity>());

        }
    }
}
