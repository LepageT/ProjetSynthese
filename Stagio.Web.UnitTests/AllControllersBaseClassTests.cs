﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Mappers;

namespace Stagio.Web.UnitTests
{
    public class AllControllersBaseClassTests
    {
        protected Fixture _fixture;
        protected const int INVALID_ID = 9999999;


        [TestInitialize]
        public void ControllerTestInit()
        {
            AutoMapperConfiguration.Configure();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            
        }
        
    }
}
