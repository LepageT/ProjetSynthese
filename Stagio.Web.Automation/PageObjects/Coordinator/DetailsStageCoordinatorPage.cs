using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class DetailsStageCoordinatorPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("details-stage-page")) != null; }
        }

        public static void GoToDetailsStage1()
        {
            Navigation.Coordinator.DetailsStage1.Select();
        }

        public static void GoToDetailsStage3()
        {
            Navigation.Coordinator.DetailsStage3.Select();
        }


        public static bool ButtonRemoveIsDisplayed()
        {
            try
            {
                Driver.Instance.FindElement(By.Id("remove-stage"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void RemoveStage()
        {
            Driver.Instance.FindElement(By.Id("remove-stage")).Click();
        }

        public static void RefuseStage()
        {
            Driver.Instance.FindElement(By.Id("refuse-stage")).Click();
        }

        public static void AcceptStage()
        {
            Driver.Instance.FindElement(By.Id("accept-stage")).Click();
        }

        
    }
}