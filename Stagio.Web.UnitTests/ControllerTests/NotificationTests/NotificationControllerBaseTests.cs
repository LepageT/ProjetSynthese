using System;
using System.Security;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.NotificationTests
{
    [TestClass]
    public class NotificationControllerBaseTests : AllControllersBaseClassTests
    {
        protected IHttpContextService httpContextService;
        protected NotificationController notificationController;
        protected NotificationService notificationService;
        protected IEntityRepository<Notification> notificationRepository;
        protected IEntityRepository<ApplicationUser> applicationUserRepository;
        
        [TestInitialize]
        public void NotificationControllerTestInit()
        {
            notificationRepository = Substitute.For<IEntityRepository<Notification>>();
            applicationUserRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            httpContextService = Substitute.For<IHttpContextService>();

            notificationService = new NotificationService(applicationUserRepository, notificationRepository);

            notificationController = new NotificationController(httpContextService, notificationService);
        }
    }
}
