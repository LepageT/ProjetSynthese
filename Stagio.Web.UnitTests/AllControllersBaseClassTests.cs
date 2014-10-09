﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.TestUtility.AutoFixture;
using Stagio.Web.Mappers;

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

            AutoMapperConfiguration.Configure();

        }
    }
}
