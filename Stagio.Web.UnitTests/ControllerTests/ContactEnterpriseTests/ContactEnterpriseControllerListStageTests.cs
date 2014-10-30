using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Apply;
using Stagio.Web.ViewModels.ContactEnterprise;
using Stagio.Web.ViewModels.Stage;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerListStageTests : ContactEnterpriseControllerBaseClassTests
    {

        [TestMethod]
        public void contactEnterpriseController_listStage_should_render_view()
        {
            var stages = _fixture.CreateMany<Stage>(5).AsQueryable();
            stageRepository.GetAll().Returns(stages);

            var result =  enterpriseController.ListStage() as ViewResult;

            result.ViewName.Should().Be("");

        }


        [TestMethod]
        public void contactEnterpriseController_listStage_should_render_view_with_stages()
        {
            var stages = _fixture.CreateMany<Stage>(5).ToList();
            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = enterpriseController.ListStage() as ViewResult;
            var model = result.Model as List<ListStage>;

            model.Count.Should().NotBe(0);


        }


        [TestMethod]
        public void contactEnterpriseController_listeStage_should_render_view_with_0_stages()
        {
       
            var result = enterpriseController.ListStage() as ViewResult;
            var model = result.Model as List<ListStage>;

            result.ViewName.Should().Be("");

        }


        public void contactEnterpriseController_listStage_should_just_render_view_with_stages_of_the_specific_contact()
        {
            //Todo : Vérifier avec un login

        }
    }
}
