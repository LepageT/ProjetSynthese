using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class ListAllStagesCoordinatorPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("listNewStages-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Coordinator.ListAllStages.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Stage/ListNewStages");
        }

        public static int CountNbStages()
        {
            var countText = Driver.Instance.FindElement(By.Id("stages-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}