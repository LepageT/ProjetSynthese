using System;
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
        protected IEntityRepository<Notification> notificationRepository;
        protected IHttpContextService httpContextService;
        protected NotificationController notificationController;
            
        [TestInitialize]
        public void NotificationControllerTestInit()
        {
            notificationRepository = Substitute.For<IEntityRepository<Notification>>();
            httpContextService = Substitute.For<IHttpContextService>();

            notificationController = new NotificationController(httpContextService, notificationRepository);
        }
    }
}
