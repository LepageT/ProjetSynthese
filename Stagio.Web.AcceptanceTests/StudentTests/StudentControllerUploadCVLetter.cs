//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Stagio.Web.Automation.PageObjects;
//using Stagio.Web.Automation.PageObjects.Student;

//namespace Stagio.Web.AcceptanceTests.StudentTests
//{
//    [TestClass]
//    public class StudentControllerUploadCVLetter : BaseTests
//    {
//        [TestMethod]
//        public void student_should_be_able_to_see_the_page_uploadCVAndLetter_if_logged_in()
//        {
//            LoginPage.GoTo();
//            LoginPage.LoginAs(StudentUsername, StudentPassword);

//            UploadCvAndLetterPage.GoToByUrl();

//            Assert.IsTrue(UploadCvAndLetterPage.IsDisplayed);

//        }

//        [TestMethod]
//        public void student_not_should_be_able_to_see_the_page_uploadCVAndLetter_if_not_logged_in()
//        {
//            UploadCvAndLetterPage.GoToByUrl();

//            Assert.IsTrue(LoginPage.IsDisplayed);

//        }

//        [TestMethod]
//        public void coordinator_should_be_able_to_choose_a_files()
//        {
//            LoginPage.GoTo();
//            LoginPage.LoginAs(StudentUsername, StudentPassword);

//            UploadCvAndLetterPage.GoToByUrl();

//            Assert.IsTrue(UploadCvAndLetterPage.SelectFiles("C:\\dev\\abc.pdf", "C:\\dev\\abcdef.pdf"));


//        }

//        [TestMethod]
//        public void student_upload_should_rest_on_to_upload_is_not_valid()
//        {
//            LoginPage.GoTo();
//            LoginPage.LoginAs(StudentUsername, StudentPassword);

//            UploadCvAndLetterPage.GoToByUrl();

//            UploadCvAndLetterPage.SelectFiles("", "");

//            Assert.IsTrue(UploadCvAndLetterPage.IsDisplayed);

//        }
//    }
//}
