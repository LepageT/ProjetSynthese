
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerBlockWebsiteAccess : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void blockWebsiteAccess_should_return_view()
        {
            var result = coordinatorController.BlockWebsiteAccess() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void blockWebsiteAccessPost_should_return_to_index_with_null_misc()
        {
            IQueryable<Misc> miscs = new EnumerableQuery<Misc>(new List<Misc>());
            miscRepository.GetAll().Returns(miscs);

            var result = coordinatorController.BlockWebsiteAccessPost() as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

        [TestMethod]
        public void blockWebsiteAccessPost_should_update_misc()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            miscRepository.GetAll().Returns(miscs);

            var result = coordinatorController.BlockWebsiteAccessPost();

            miscRepository.Received().Update(Arg.Any<Misc>());
        }
    }
}
