using System;
using AutoMapper.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.DataLayer.EntityFramework;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Controllers;
using Stagio.Web.Mappers;
using NSubstitute;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected CoordinatorController coordinatorController;

        protected IEntityRepository<Coordinator> coordinatorRepository;
        protected IEntityRepository<Invitation> invitationRepository;
        protected IEntityRepository<ContactEnterprise> enterpriseRepository;
        protected IEntityRepository<Apply> applyRepository;
        protected IEntityRepository<Stage> stageRepository;
        protected IEntityRepository<Student> studentRepository;
        protected IEntityRepository<Interview> interviewRepository; 
        protected IEntityRepository<InvitationContactEnterprise> invitationContactRepository;
        protected IHttpContextService httpContextService;
        protected IEntityRepository<Notification> notificationRepository;
        protected IEntityRepository<ApplicationUser> applicationRepository; 
        protected IEntityRepository<Misc> miscRepository; 
        protected IAccountService accountService;
        protected INotificationService notificationService;
        protected IMailler mailler;
        protected IEntityRepository<StageAgreement> stageAgreementRepository;

        [TestInitialize]
        public void CoordinatorControllerTestInit()
        {

            coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            invitationRepository = Substitute.For<IEntityRepository<Invitation>>();
            enterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            studentRepository = Substitute.For<IEntityRepository<Student>>();
            interviewRepository = Substitute.For<IEntityRepository<Interview>>();
            accountService = Substitute.For<IAccountService>();
            invitationContactRepository = Substitute.For<IEntityRepository<InvitationContactEnterprise>>();
            accountService = Substitute.For<IAccountService>();
            httpContextService = Substitute.For<IHttpContextService>();
            notificationRepository = Substitute.For<IEntityRepository<Notification>>();
            applicationRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            mailler = Substitute.For<IMailler>();
            stageAgreementRepository = Substitute.For<IEntityRepository<StageAgreement>>();

            notificationService = new NotificationService(applicationRepository, notificationRepository);
            miscRepository = Substitute.For<IEntityRepository<Misc>>();

            coordinatorController = new CoordinatorController(enterpriseRepository, coordinatorRepository, invitationRepository, mailler,
                accountService, invitationContactRepository, applyRepository, stageRepository, studentRepository,
                interviewRepository, stageAgreementRepository,notificationService, httpContextService, miscRepository);


            coordinatorController = new CoordinatorController(enterpriseRepository, coordinatorRepository, invitationRepository, mailler, accountService, invitationContactRepository, applyRepository, stageRepository, studentRepository, interviewRepository, stageAgreementRepository, notificationService,httpContextService,  miscRepository);
        }
    }
}
