using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.EnterpriseTests
{
    [TestClass]
    public class EnterpriseControllerCreateStageTests : BaseTests
    {

        [TestMethod]
        public void enterprise_should_be_able_to_see_the_page_to_create_stage()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Enterprise/CreateStage");

            try
            {
                _driver.FindElement(By.Id("create-stage"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant create-stage non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void enterprise_should_be_able_to_create_a_stage()
        {
            const string ENTERPRISE_NAME = "Les lapins joyeux";
            const string ENTERPRISE_ADRESSE = "10 rue des Bucherons";
            const string ENTERPRISE_RESP_NAME = "Luke";
            const string ENTERPRISE_RESP_TITLE = "Jedi";
            const string ENTERPRISE_RESP_EMAIL = "skywalker@r2d2.com";
            const string ENTERPRISE_RESP_PHONE = "581-341-0021";
            const string ENTERPRISE_RESP_POSTE = "3";
            const string ENTERPRISE_CONTACT_NAME = "C3P0";
            const string ENTERPRISE_CONTACT_TITLE = "Robot en chef";
            const string ENTERPRISE_CONTACT_EMAIL = "c3po@r2d2.com";
            const string ENTERPRISE_CONTACT_PHONE = "581-341-0000";
            const string ENTERPRISE_CONTACT_POSTE = "42";
            const string STAGE_DESC = "Résister au dark side, trouver 2 droids";
            const string STAGE_ENVIRONNEMENT = "Sabre laser, vaisseaux, droids, clones, Death Star...";
            const string NBR_STAGE = "10000";
            const string SUBMIT_TO_NAME = "Yoda";
            const string SUBMIT_TO_TITLE = "Maitre";
            const string SUBMIT_TO_EMAIL = "yoda@r2d2.com";
            const string SUBMIT_LIMIT_DATE = "2301-10-31";

            _driver.Navigate().GoToUrl("http://thomarelau.local/Enterprise/CreateStage");

            _driver.FindElement(By.Id("CompanyName")).SendKeys(ENTERPRISE_NAME);
            _driver.FindElement(By.Id("Adresse")).SendKeys(ENTERPRISE_ADRESSE);
            _driver.FindElement(By.Id("ResponsableToName")).SendKeys(ENTERPRISE_RESP_NAME);
            _driver.FindElement(By.Id("ResponsableToTitle")).SendKeys(ENTERPRISE_RESP_TITLE);
            _driver.FindElement(By.Id("ResponsableToEmail")).SendKeys(ENTERPRISE_RESP_EMAIL);
            _driver.FindElement(By.Id("ResponsableToPhone")).SendKeys(ENTERPRISE_RESP_PHONE);
            _driver.FindElement(By.Id("ResponsableToPoste")).SendKeys(ENTERPRISE_RESP_POSTE);
            _driver.FindElement(By.Id("ContactToName")).SendKeys(ENTERPRISE_CONTACT_NAME);
            _driver.FindElement(By.Id("ContactToTitle")).SendKeys(ENTERPRISE_CONTACT_TITLE);
            _driver.FindElement(By.Id("ContactToEmail")).SendKeys(ENTERPRISE_CONTACT_EMAIL);
            _driver.FindElement(By.Id("ContactToPhone")).SendKeys(ENTERPRISE_CONTACT_PHONE);
            _driver.FindElement(By.Id("ContactToPoste")).SendKeys(ENTERPRISE_CONTACT_POSTE);
            _driver.FindElement(By.Id("StageDescription")).SendKeys(STAGE_DESC);
            _driver.FindElement(By.Id("EnvironnementDescription")).SendKeys(STAGE_ENVIRONNEMENT);
            _driver.FindElement(By.Id("NbrStagiaire")).SendKeys(NBR_STAGE);
            _driver.FindElement(By.Id("SubmitToName")).SendKeys(SUBMIT_TO_NAME);
            _driver.FindElement(By.Id("SubmitToTitle")).SendKeys(SUBMIT_TO_TITLE);
            _driver.FindElement(By.Id("SubmitToEmail")).SendKeys(SUBMIT_TO_EMAIL);
            _driver.FindElement(By.Id("LimitDate")).SendKeys(SUBMIT_LIMIT_DATE);

            _driver.FindElement(By.Id("btn-create")).Click();

            try
            {
                _driver.FindElement(By.Id("create-succeed"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant create-succeed non trouvé sur la page.");
            }
        }

    }
}
