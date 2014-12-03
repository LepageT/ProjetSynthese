using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Automation.Selenium;


namespace Stagio.Web.AcceptanceTests
{
    [TestClass]
    public class BaseTests
    {

        protected const string CoordonatorUsername = "coordonnateur@stagio.com";
        protected const string CoordonatorPassword = "test4test1";

        protected const string ContactEnterpriseUsername = "bond.james.007@hotmail.com ";
        protected const string ContactEnterprisePassword = "qwerty12";

        protected const string StudentUsername = "1234567";
        protected const string StudentPassword = "qwerty12";



        protected Fixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture();//??fixture dans les acceptances tests??
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            Driver.Initialize();
           
        }

        [TestCleanup]
        public void Cleanup()
        {
           Driver.Close();
        }

        
    }
}
