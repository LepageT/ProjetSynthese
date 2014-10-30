using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerUploadTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_see_the_page_upload_student_if_logged_in()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");

            try
            {
                _driver.FindElement(By.Id("upload-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant upload-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_not_should_be_able_to_see_the_page_upload_student_if_not_logged_in()
        {
            
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");

            try
            {
                _driver.FindElement(By.Id("login-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant upload-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_should_be_able_to_choose_a_file_csv()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");
     
            try
            {

                _driver.FindElement(By.Id("file")).SendKeys("C:\\dev\\abc.csv");

            }
            catch (Exception)
            {

                Assert.Fail("Le fichier n'a pas été choisi");
            }
            
        }

        [TestMethod]
        public void coordinator_should_not_be_able_to_import_an_another_file_than_csv()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");
            _driver.FindElement(By.Id("file")).SendKeys("C:\\dev\\abc.txt");
            _driver.FindElement(By.Id("button-upload")).Click();
            try
            {
                _driver.FindElement(By.Id("upload-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant upload-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_upload_should_redirect_to_CreateList_is_valid()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");
            _driver.FindElement(By.Id("file")).SendKeys("C:\\dev\\abc.csv");
            _driver.FindElement(By.Id("button-upload")).Click();
            try
            {
                _driver.FindElement(By.Id("createList-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant createList-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_upload_should_rest_on_to_upload_is_not_valid()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Student/Upload");
            _driver.FindElement(By.Id("button-upload")).Click();

            try
            {
                _driver.FindElement(By.Id("upload-page"));

            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant upload-page non trouvé sur la page.");
            }
        }

    }
}
