using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected StageAgreementController stageAgreementController;
        protected IEntityRepository<StageAgreement> stageAgreementRepository;
        protected IEntityRepository<Apply> applyRepository;
        protected IEntityRepository<Stage> stageRepository;
        protected IEntityRepository<Student> studentRepository;
        protected IHttpContextService httpContextService;
        protected IEntityRepository<ApplicationUser> accountRepository;
        protected IEntityRepository<ContactEnterprise> contactEnterpriseRepository;
            
        [TestInitialize]
        public void stageAgreementTestInit()
        {
            stageAgreementRepository = Substitute.For<IEntityRepository<StageAgreement>>();
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            studentRepository = Substitute.For<IEntityRepository<Student>>();
            httpContextService = Substitute.For<IHttpContextService>();
            accountRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            contactEnterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();

            stageAgreementController = new StageAgreementController(stageAgreementRepository, applyRepository, stageRepository, studentRepository, httpContextService, accountRepository, contactEnterpriseRepository);
        }
    }
}
