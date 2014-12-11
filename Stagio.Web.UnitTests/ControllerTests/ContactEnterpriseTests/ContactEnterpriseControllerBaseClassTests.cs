using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected ContactEnterpriseController enterpriseController;
        protected IAccountService accountService;
        protected IHttpContextService httpContext;
        protected IMailler mailler;
        protected IEntityRepository<ContactEnterprise> enterpriseRepository;
        protected IEntityRepository<Stage> stageRepository;
        protected IEntityRepository<Apply> applyRepository;
        protected IEntityRepository<Student> studentRepository;
        protected IEntityRepository<InvitationContactEnterprise> invitationRepository;
        protected IEntityRepository<Notification> notificationRepository;
        protected IEntityRepository<ApplicationUser> applicationUserRepository;
        protected IEntityRepository<Interview> interviewRepository;
        protected INotificationService notification;


        [TestInitialize]
        public void ContactControllerTestInit()
        {
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            studentRepository = Substitute.For<IEntityRepository<Student>>();
            enterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            mailler = Substitute.For<IMailler>();
            invitationRepository = Substitute.For<IEntityRepository<InvitationContactEnterprise>>();
            httpContext = Substitute.For<IHttpContextService>();
            notificationRepository = Substitute.For<IEntityRepository<Notification>>();
            accountService = Substitute.For<IAccountService>();
            applicationUserRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
             interviewRepository = Substitute.For<IEntityRepository<Interview>>();
            notification = new NotificationService(applicationUserRepository, notificationRepository);


            enterpriseController = new ContactEnterpriseController(enterpriseRepository, stageRepository, accountService, mailler, applyRepository, studentRepository, httpContext, invitationRepository, notification, interviewRepository);

        }
    }
}
