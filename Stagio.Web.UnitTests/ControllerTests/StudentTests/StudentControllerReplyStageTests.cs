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

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerReplyStageTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void replyStage_action_should_render_default_view()
        {
            var applyStage = _fixture.Create<Apply>();
            applyRepository.GetById(applyStage.Id).Returns(applyStage);

            var result = studentController.ReplyStage(applyStage.Id) as ViewResult;

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void replyStage_should_return_http_not_found_when_IdApply_is_not_valid()
        {
            var result = studentController.ReplyStage(999999999);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void replyStage_post_should_update_DB_with_student_reply()
        {
            var applyStage = _fixture.Create<Apply>();
            applyRepository.GetById(applyStage.IdStage).Returns(applyStage);

            studentController.ReplyStage(applyStage.IdStage, "Accepter");

            applyRepository.Received().Update(Arg.Is<Apply>(x => x.StudentReply == 1));

        }

        [TestMethod]
        public void replySTage_post_should_return_http_not_found_when_IdApply_is_not_valid()
        {
            var apply = _fixture.Create<ViewModels.Student.Apply>();
            applyRepository.GetById(Arg.Any<int>()).Returns(a => null);

            var result = studentController.ReplyStage(apply.Id, "Accepter");

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void replySTage_post_should_redirect_to_ApplyList_on_success()
        {
            var applyStage = _fixture.Create<Apply>();
            applyRepository.GetById(applyStage.Id).Returns(applyStage);

            var routeResult = studentController.ReplyStage(applyStage.Id, "Refuser") as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Student.Views.ViewNames.ApplyList);
        }
    }
}
