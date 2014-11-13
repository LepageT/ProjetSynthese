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

        
        protected IAccountService accountService;
        protected IMailler mailler;

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
            

            mailler = Substitute.For<IMailler>();

            coordinatorController = new CoordinatorController(enterpriseRepository, coordinatorRepository, invitationRepository, mailler, accountService, invitationContactRepository, applyRepository, stageRepository, studentRepository, interviewRepository);
        }
    }
}
