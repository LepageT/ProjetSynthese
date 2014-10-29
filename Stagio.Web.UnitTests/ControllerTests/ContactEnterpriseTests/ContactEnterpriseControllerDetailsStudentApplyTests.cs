using System;
using System.Linq;
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
        public void contactEnterprise_detailsStudentApply_should_render_view_with_student_details()
        {
            var apply = _fixture.CreateMany<Apply>(1).ToList();
            applyRepository.GetAll().Returns(apply.AsQueryable());


            var result = enterpriseController.DetailsStudentApply(apply[0].Id) as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
