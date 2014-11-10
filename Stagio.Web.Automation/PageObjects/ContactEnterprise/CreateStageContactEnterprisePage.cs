using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class CreateStageContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("create-stage")) != null; }
        }

        public static void GoTo()
        {
            Navigation.ContactEnterprise.CreateStage.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/CreateStage");
        }

        public static void CreateStage()
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
            const string STAGE_TITLE = "Résister au dark side, trouver 2 droids";
            const string NBR_STAGE = "10";
            const string SUBMIT_TO_NAME = "Yoda";
            const string SUBMIT_TO_TITLE = "Maitre";
            const string SUBMIT_TO_EMAIL = "yoda@r2d2.com";
            const string SUBMIT_LIMIT_DATE = "2301-10-31";

            Driver.Instance.FindElement(By.Id("CompanyName")).SendKeys(ENTERPRISE_NAME);
            Driver.Instance.FindElement(By.Id("Adresse")).SendKeys(ENTERPRISE_ADRESSE);
            Driver.Instance.FindElement(By.Id("ResponsableToName")).SendKeys(ENTERPRISE_RESP_NAME);
            Driver.Instance.FindElement(By.Id("ResponsableToTitle")).SendKeys(ENTERPRISE_RESP_TITLE);
            Driver.Instance.FindElement(By.Id("ResponsableToEmail")).SendKeys(ENTERPRISE_RESP_EMAIL);
            Driver.Instance.FindElement(By.Id("ResponsableToPhone")).SendKeys(ENTERPRISE_RESP_PHONE);
            Driver.Instance.FindElement(By.Id("ResponsableToPoste")).SendKeys(ENTERPRISE_RESP_POSTE);
            Driver.Instance.FindElement(By.Id("ContactToName")).SendKeys(ENTERPRISE_CONTACT_NAME);
            Driver.Instance.FindElement(By.Id("ContactToTitle")).SendKeys(ENTERPRISE_CONTACT_TITLE);
            Driver.Instance.FindElement(By.Id("ContactToEmail")).SendKeys(ENTERPRISE_CONTACT_EMAIL);
            Driver.Instance.FindElement(By.Id("ContactToPhone")).SendKeys(ENTERPRISE_CONTACT_PHONE);
            Driver.Instance.FindElement(By.Id("ContactToPoste")).SendKeys(ENTERPRISE_CONTACT_POSTE);
            Driver.Instance.FindElement(By.Id("StageTitle")).SendKeys(STAGE_TITLE);
            Driver.Instance.FindElement(By.Id("StageDescription")).SendKeys(STAGE_DESC);
            Driver.Instance.FindElement(By.Id("EnvironnementDescription")).SendKeys(STAGE_ENVIRONNEMENT);
            Driver.Instance.FindElement(By.Id("NbrStagiaire")).SendKeys(NBR_STAGE);
            Driver.Instance.FindElement(By.Id("SubmitToName")).SendKeys(SUBMIT_TO_NAME);
            Driver.Instance.FindElement(By.Id("SubmitToTitle")).SendKeys(SUBMIT_TO_TITLE);
            Driver.Instance.FindElement(By.Id("SubmitToEmail")).SendKeys(SUBMIT_TO_EMAIL);
            Driver.Instance.FindElement(By.Id("LimitDate")).SendKeys(SUBMIT_LIMIT_DATE);

            Driver.Instance.FindElement(By.Id("btn-create")).Click();
        }

        public static bool ConfirmationPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("create-succeed")) != null; }
        }
    }
}