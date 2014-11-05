using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;

namespace Stagio.Web.AcceptanceTests.AccountTests
{
    [TestClass]
    public class AccountControllerDetailsTests : BaseTests
    {
        [TestMethod]
        public void applicationUser_can_see_his_profil()
        {
            DetailsAccountPage.GoToByUrl1();

            Assert.IsTrue(DetailsAccountPage.IsDisplayed);
           
        }

    }
}
