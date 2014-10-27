using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerStageListTest : BaseTests
    {
        [TestMethod]
        public void student_home_page_should_display_stages()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/StageList");
            var countText = _driver.FindElement(By.Id("stages-count")).Text;
            var stageCount =  int.Parse(countText.Split(' ')[0]);

            Assert.IsTrue(stageCount > 0);
        }
    }
}
