using System;
using Stagio.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Stagio.Web.Automation.PageObjects
{
    public class HomePage
    {
        /*public static bool IsCoordinatorLogged
        {
            get
            {
                var body = Driver.Instance.FindElement(By.ClassName("navbar"));
                return body.Text.Contains("Admin");
            }
        }
        public static bool IsStudentLogged
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("writer-menu"));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool IsContactEnterpriseLogged
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("writer-menu"));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }*/

       

        public static void GoTo()
        {
            Navigation.AllUsers.Home.Select();
        }
    }
}