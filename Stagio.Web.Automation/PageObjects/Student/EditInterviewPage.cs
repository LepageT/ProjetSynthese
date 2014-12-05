using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class EditInterviewPage
    {

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Interview/Edit?id=2");
        }
        
        public static void EditAnInterview(DateTime dateInterview, DateTime dateOffer, DateTime dateAcceptOffer, bool isPresent)
        {
            Driver.Instance.FindElement(By.Id("datetimepicker")).Clear();
            Driver.Instance.FindElement(By.Id("datetimepicker")).SendKeys(dateInterview.ToString());
            Driver.Instance.FindElement(By.Id("Present")).SendKeys(isPresent.ToString());
            Driver.Instance.FindElement(By.Id("datetimepickerDateOffer")).Clear();
            Driver.Instance.FindElement(By.Id("datetimepickerDateOffer")).SendKeys(dateOffer.ToString());
            Driver.Instance.FindElement(By.Id("datetimepickerDateAcceptOffer")).Clear();
            Driver.Instance.FindElement(By.Id("datetimepickerDateAcceptOffer")).SendKeys(dateAcceptOffer.ToString());
            Driver.Instance.FindElement(By.Id("datetimepickerDateAcceptOffer")).Submit();

         
        }

        public static bool EditVerification(DateTime dateInterview, DateTime dateOffer, DateTime dateAcceptOffer)
        {
            GoToByUrl();
            
            var dateInterviewDisplayed = Driver.Instance.FindElement(By.Id("datetimepicker")).GetAttribute("value");
            var dateOfferDisplayed = Driver.Instance.FindElement(By.Id("datetimepickerDateOffer")).GetAttribute("value");
            var dateAcceptOfferDisplayed = Driver.Instance.FindElement(By.Id("datetimepickerDateAcceptOffer")).GetAttribute("value");

            if (DateTime.Parse(dateInterviewDisplayed) == dateInterview && DateTime.Parse(dateOfferDisplayed).ToShortDateString() == dateOffer.ToShortDateString() && DateTime.Parse(dateAcceptOfferDisplayed).ToShortDateString() == dateAcceptOffer.ToShortDateString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}