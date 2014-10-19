using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Mappers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests
{
    public class AllControllersBaseClassTests
    {
        protected Fixture _fixture;


        [TestInitialize]
        public void ControllerTestInit()
        {
 
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());
            _fixture.Customizations.Add(new CollectionPropertyOmitter());

            AutoMapperConfiguration.Configure();

        }
    }
}
