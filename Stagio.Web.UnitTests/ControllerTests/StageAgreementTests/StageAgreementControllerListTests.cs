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
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Interviews;
using Stagio.Web.ViewModels.StageAgreement;

namespace Stagio.Web.UnitTests.ControllerTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerListTests : StageAgreementControllerBaseClassTests
    {
        [TestMethod]
        public void user_stageAgreement_list_should_render_view()
        {
            var account = _fixture.Create<ApplicationUser>();
            var userRole = new UserRole();
            userRole.RoleName = RoleName.Coordinator;
            account.Roles.Add(userRole);
            httpContextService.GetUserId().Returns(account.Id);
            accountRepository.GetById(account.Id).Returns(account);
            var stageAgreements = _fixture.CreateMany<StageAgreement>(5).AsQueryable();
            stageAgreementRepository.GetAll().Returns(stageAgreements);
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var student = _fixture.Create<Student>();
            accountRepository.GetById(student.Id).Returns(student);
            foreach (var stageAgreement in stageAgreements)
            {
                stageAgreement.IdStudentSigned = student.Id;
                stageAgreement.IdStage = stage.Id;
            }

            var result = stageAgreementController.List() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void user_stageAgreement_list_should_render_view_with_ListStageAgreementsNotSigned()
        {
            var account = _fixture.Create<ApplicationUser>();
            var userRole = new UserRole();
            userRole.RoleName = RoleName.Coordinator;
            account.Roles.Add(userRole);
            httpContextService.GetUserId().Returns(account.Id);
            accountRepository.GetById(account.Id).Returns(account);
            var stageAgreements = _fixture.CreateMany<StageAgreement>(5).ToList();
            stageAgreements[0].CoordinatorHasSigned = false;
            stageAgreementRepository.GetAll().Returns(stageAgreements.AsQueryable());
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var student = _fixture.Create<Student>();
            accountRepository.GetById(student.Id).Returns(student);
            foreach (var stageAgreement in stageAgreements)
            {
                stageAgreement.IdStudentSigned = student.Id;
                stageAgreement.IdStage = stage.Id;
            }

            var result = stageAgreementController.List() as ViewResult;
            var model = result.Model as ListStageAgreement;
            int nbStages = model.ListStageAgreementNotSigned.Count();

            nbStages.Should().NotBe(0);
        }

        [TestMethod]
        public void user_stageAgreement_list_should_render_view_with_ListStageAgreementsSigned()
        {
            var account = _fixture.Create<ApplicationUser>();
            var userRole = new UserRole();
            userRole.RoleName = RoleName.Coordinator;
            account.Roles.Add(userRole);
            httpContextService.GetUserId().Returns(account.Id);
            accountRepository.GetById(account.Id).Returns(account);
            var stageAgreements = _fixture.CreateMany<StageAgreement>(5).ToList();
            stageAgreements[0].CoordinatorHasSigned = true;
            stageAgreementRepository.GetAll().Returns(stageAgreements.AsQueryable());
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var student = _fixture.Create<Student>();
            accountRepository.GetById(student.Id).Returns(student);
            foreach (var stageAgreement in stageAgreements)
            {
                stageAgreement.IdStudentSigned = student.Id;
                stageAgreement.IdStage = stage.Id;
            }

            var result = stageAgreementController.List() as ViewResult;
            var model = result.Model as ListStageAgreement;
            int nbStages = model.ListStagesAgreementsSigned.Count();

            nbStages.Should().NotBe(0);
        }
    }
}
