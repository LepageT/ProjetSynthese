﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class ApplyListStudentPage
    {
        public static void GoTo()
        {
            Navigation.Student.ListApply.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Student/ApplyList");
        }

        public static bool HasStage
        {
            get
            {
                return GetStageCount() > 0;
            }
        }

        private static int GetStageCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("stages-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool AccessStageDescription()
        {
            Driver.Instance.FindElement(By.Id("details-stages1")).Click();
            try
            {
                Driver.Instance.FindElement(By.Id("view-stage-info"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        public static void ClickToRemove()
        {
            Driver.Instance.FindElement(By.Id("remove-apply")).Click();
           
        }

        public static void ClickToReApply()
        {
            Driver.Instance.FindElement(By.Id("reapply-apply")).Click();

        }

        public static bool ConfirmationRemoveIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationRemoveApplyStudent-page")) != null; }
        }

        public static bool ConfirmationReApplyIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationReApplyApplyStudent-page")) != null; }
        }
    }
}