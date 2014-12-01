using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Interviews;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerDraftListTest : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contactEnterprise_draft_list_should_render_view()
        {
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.EnterpriseName = "Test";
            var drafts = _fixture.Build<Stage>()
                .With(x => x.CompanyName, contactEnterprise.EnterpriseName)
                .With(x => x.Status, StageStatus.Draft)
                .CreateMany(5);
            stageRepository.GetAll().Returns(drafts.AsQueryable());
            httpContext.GetUserId().Returns(contactEnterprise.Id);
            enterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);

            var result = enterpriseController.DraftList() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contactEnterprise_draft_list_should_render_view_with_draft()
        {
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.EnterpriseName = "Test";
            var drafts = _fixture.Build<Stage>()
                .With(x => x.CompanyName, contactEnterprise.EnterpriseName)
                .With(x => x.Status, StageStatus.Draft)
                .CreateMany(5);
            stageRepository.GetAll().Returns(drafts.AsQueryable());
            httpContext.GetUserId().Returns(contactEnterprise.Id);
            enterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);

            var result = enterpriseController.DraftList() as ViewResult;
            var models = result.Model as List<ViewModels.ContactEnterprise.Draft>;

            models.Count.Should().NotBe(0);

        }

        [TestMethod]
        public void contactEnterprise_draft_list_should_render_view_with_0_draft()
        {
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.EnterpriseName = "Test";
            var drafts = _fixture.Build<Stage>()
                .With(x => x.CompanyName, "Test2")
                .With(x => x.Status, StageStatus.Draft)
                .CreateMany(5);
            stageRepository.GetAll().Returns(drafts.AsQueryable());
            httpContext.GetUserId().Returns(contactEnterprise.Id);
            enterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);

            var result = enterpriseController.DraftList() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contactEnterprise_draft_list_should_render_view_with_draft_specific_to_contact()
        {
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.EnterpriseName = "Test";
            var drafts = _fixture.Build<Stage>()
                .With(x => x.CompanyName, contactEnterprise.EnterpriseName)
                .With(x => x.Status, StageStatus.Draft)
                .CreateMany(5);

            drafts.FirstOrDefault().CompanyName = "test 2";
            stageRepository.GetAll().Returns(drafts.AsQueryable());
            httpContext.GetUserId().Returns(contactEnterprise.Id);
            enterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);

            var result = enterpriseController.DraftList() as ViewResult;
            var models = result.Model as List<ViewModels.ContactEnterprise.Draft>;

            models.Count.Should().Be(4);
        }
    }
}
