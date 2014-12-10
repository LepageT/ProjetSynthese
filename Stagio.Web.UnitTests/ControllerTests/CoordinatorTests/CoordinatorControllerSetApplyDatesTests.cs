using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerSetApplyDatesTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void SetApplyDates_should_return_empty_view_with_empty_misc()
        {
            IQueryable<Misc> miscs = new EnumerableQuery<Misc>(new List<Misc>());
            miscRepository.GetAll().Returns(miscs);

            var result = coordinatorController.SetApplyDates() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void SetApplyDates_should_return__view_with_view_model_with_nonempty_miscs()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            miscs.First().StartApplyDate = DateTime.Now.ToString();
            miscs.First().EndApplyDate = DateTime.Now.AddDays(1).ToString();
            miscRepository.GetAll().Returns(miscs);
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.ApplyDatesLimit>(miscs.First());
            viewModelExpected.DateBegin = miscs.First().StartApplyDate;
            viewModelExpected.DateEnd = miscs.First().EndApplyDate;

            var result = coordinatorController.SetApplyDates() as ViewResult;
            
            var viewModelObtained = result.ViewData.Model as ViewModels.Coordinator.ApplyDatesLimit;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 
        }

       

        

        [TestMethod]
        public void SetApplyDates_post_should_return_default_view_with_invalid_enddate()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            miscRepository.GetAll().Returns(miscs);
            misc.StartApplyDate = DateTime.Now.AddDays(1).ToString();
            misc.EndApplyDate = DateTime.Now.AddDays(-1).ToString();
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.ApplyDatesLimit>(misc);
            viewModelExpected.DateBegin = misc.StartApplyDate;
            viewModelExpected.DateEnd = misc.EndApplyDate;

            var result = coordinatorController.SetApplyDates(viewModelExpected) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void SetApplyDates_post_should_add_with_empty_misc()
        {
            IQueryable<Misc> miscs = new EnumerableQuery<Misc>(new List<Misc>());
            miscRepository.GetAll().Returns(miscs);
            var viewModelExpected =  new ViewModels.Coordinator.ApplyDatesLimit();
            viewModelExpected.DateBegin = DateTime.Now.ToString();
            viewModelExpected.DateEnd = DateTime.Now.AddDays(1).ToString();

            var result = coordinatorController.SetApplyDates(viewModelExpected);

            miscRepository.Received().Add(Arg.Any<Misc>());
        }

        [TestMethod]
        public void SetApplyDates_post_should_update_with_nonmempty_misc()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            miscRepository.GetAll().Returns(miscs);
            misc.StartApplyDate = DateTime.Now.AddDays(1).ToString();
            misc.EndApplyDate = DateTime.Now.AddDays(2).ToString();
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.ApplyDatesLimit>(misc);
            viewModelExpected.DateBegin = misc.StartApplyDate;
            viewModelExpected.DateEnd = misc.EndApplyDate;

            var result = coordinatorController.SetApplyDates(viewModelExpected);

            miscRepository.Received().Update(Arg.Any<Misc>());
        }

        [TestMethod]
        public void SetApplyDates_post_should_return_to_coordinator_index_after_valid_action()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            miscRepository.GetAll().Returns(miscs);
            misc.StartApplyDate = DateTime.Now.AddDays(1).ToString();
            misc.EndApplyDate = DateTime.Now.AddDays(2).ToString();
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.ApplyDatesLimit>(misc);
            viewModelExpected.DateBegin = misc.StartApplyDate;
            viewModelExpected.DateEnd = misc.EndApplyDate;

            var result = coordinatorController.SetApplyDates(viewModelExpected) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

    }
}
