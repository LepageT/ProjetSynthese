using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerDetailsStudentApplyTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_return_confirmation_accept_view_on_accept()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.Add(apply);
            applyRepository.GetById(apply.Id).Returns(apply);

            var result = enterpriseController.DetailsStudentApplyPost("Accepter", apply.Id) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.ContactEnterprise.Views.ViewNames.AcceptApplyConfirmation);
        }

        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_return_confirmation_refuse_view_on_refuse()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.Add(apply);
            applyRepository.GetById(apply.Id).Returns(apply);

            var result = enterpriseController.DetailsStudentApplyPost("Refuser", apply.Id) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.ContactEnterprise.Views.ViewNames.RefuseApplyConfirmation);
        }

        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_update_apply_status_on_accept()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.Add(apply);
            applyRepository.GetById(apply.Id).Returns(apply);

            var result = enterpriseController.DetailsStudentApplyPost("Accepter", apply.Id) as RedirectToRouteResult;

            applyRepository.Update(Arg.Is<Apply>(x => x.Status == 1));
        }

        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_update_apply_status_on_refuse()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.Add(apply);
            applyRepository.GetById(apply.Id).Returns(apply);

            var result = enterpriseController.DetailsStudentApplyPost("Accepter", apply.Id) as RedirectToRouteResult;
            
            applyRepository.Update(Arg.Is<Apply>(x => x.Status == 2));
        }
    }
}
