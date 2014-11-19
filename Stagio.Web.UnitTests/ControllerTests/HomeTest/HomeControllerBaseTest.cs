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

namespace Stagio.Web.UnitTests.ControllerTests.HomeTest
{
    [TestClass]
    public class HomeControllerBaseTest
    {
        protected HomeController homeController;

        
        [TestInitialize]
        public void ContactControllerTestInit()
        {
            
            homeController = new HomeController();

        }
    }
}
