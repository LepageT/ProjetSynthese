using System;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Stagio.Web.Automation.Selenium
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress
        {
            get { return "http://thomarelau.local"; }
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Window.Maximize();

            //Selenium doit attendre 5 secondes avant d'indiquer qu'un objet n'est pas sur une page.
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            //Efface et peuple la BD avec des données pour les tests
            Instance.Navigate().GoToUrl(BaseAddress + "/Ci");

            Instance.FindElement(By.Id("go_home")).Click();
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void GetScreenShoot(string screenShootName)
        {
            var screenShoot = ((ITakesScreenshot)Instance).GetScreenshot();
            screenShoot.SaveAsFile(screenShootName + "_" +
                                   DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") +
                                   ".png",
                                   ImageFormat.Png);
        }
    }
}