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

        
        protected IAccountService _accountService;
        protected IMailler mailler;

        [TestInitialize]
        public void CoordinatorControllerTestInit()
        {

            coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            invitationRepository = Substitute.For<IEntityRepository<Invitation>>();
            enterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            _accountService = Substitute.For<IAccountService>();
            

            mailler = Substitute.For<IMailler>();

            coordinatorController = new CoordinatorController(enterpriseRepository, coordinatorRepository, invitationRepository, mailler, _accountService);
        }
    }
}
