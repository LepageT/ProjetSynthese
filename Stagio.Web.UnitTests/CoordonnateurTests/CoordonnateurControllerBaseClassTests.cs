using System;
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

namespace Stagio.Web.UnitTests.CoordonnateurTests
{
    [TestClass]
    public class CoordonnateurControllerBaseClassTests
    {
        protected CoordonnateurController coordonnateurController;
        protected Fixture _fixture;
        protected IEntityRepository<Coordonnateur> coordonnateurRepository;
        protected IEntityRepository<Invitation> invitationRepository;
        protected IMailler mailler;

        [TestInitialize]
        public void ControllerTestInit()
        {
            AutoMapperConfiguration.Configure();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            coordonnateurRepository = Substitute.For<IEntityRepository<Coordonnateur>>();
            invitationRepository = Substitute.For<IEntityRepository<Invitation>>();

            mailler = Substitute.For<IMailler>();

            coordonnateurController = new CoordonnateurController(coordonnateurRepository, invitationRepository, mailler);
        }
    }
}
