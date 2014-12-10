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
        public void coordinator_stageAgreement_list_should_render_view_with_ListStageAgreementsNotSigned()
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

        [TestMethod]
        public void contactEnterprise_stageAgreement_list_should_render_view_with_ListStageAgreementsNotSigned()
        {
            var account = _fixture.Create<ApplicationUser>();
            var userRole = new UserRole();
            userRole.RoleName = RoleName.ContactEnterprise;
            account.Roles.Add(userRole);
            httpContextService.GetUserId().Returns(account.Id);
            accountRepository.GetById(account.Id).Returns(account);
            var stageAgreements = _fixture.CreateMany<StageAgreement>(5).ToList();
            stageAgreements[0].ContactEnterpriseHasSigned = false;
            stageAgreementRepository.GetAll().Returns(stageAgreements.AsQueryable());
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var student = _fixture.Create<Student>();
            accountRepository.GetById(student.Id).Returns(student);
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.Id = account.Id;
            contactEnterprise.EnterpriseName = stage.CompanyName;
            contactEnterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);
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
        public void student_stageAgreement_list_should_render_view_with_ListStageAgreementsNotSigned()
        {
            var account = _fixture.Create<ApplicationUser>();
            var userRole = new UserRole();
            userRole.RoleName = RoleName.Student;
            account.Roles.Add(userRole);
            httpContextService.GetUserId().Returns(account.Id);
            accountRepository.GetById(account.Id).Returns(account);
            var stageAgreements = _fixture.CreateMany<StageAgreement>(5).ToList();
            stageAgreements[0].StudentHasSigned = false;
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var student = _fixture.Create<Student>();
            student.Id = account.Id;
            student.Roles.Add(userRole);
            accountRepository.GetById(student.Id).Returns(student);
            stageAgreements[0].IdStudentSigned = student.Id;
            stageAgreementRepository.GetAll().Returns(stageAgreements.AsQueryable());
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
    }
}
