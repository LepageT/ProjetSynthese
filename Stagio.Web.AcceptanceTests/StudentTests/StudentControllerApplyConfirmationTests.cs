using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyConfirmationTests : BaseTests
    {
        [TestMethod]
        public void student_should_see_apply_confirmation_after_he_apply_on_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyStudentPage.GoToByUrl();

            ApplyStudentPage.SelectFiles("file1.pdf", "file2.pdf");

            Assert.IsTrue(ConfirmationUploadCVLetterPage.IsDisplayed);
        }

        [TestMethod]
        public void student_should_download_his_files_of_the_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyStudentPage.GoToByUrl();

            ApplyStudentPage.SelectFiles("file1.pdf", "file2.pdf");

            ConfirmationUploadCVLetterPage.ClickFile();
            //Ce test ne peut fonctionner que si FireFox n'ouvre pas de boite de dialogue.
            //Voir comment indiquer à FireFox de ne pas ouvrir de boite de dialogue avec l'utlisation d'un profile
            //dans les méthodes Initialize et CreateSeleniumProfile de la classe Driver (dossier Selenium du projet Web.Automation)

            //Assert
            //En cas d'erreur, une page autre que DownloadIndex sera affichée. 
            //Donc s'il n'y a pas d'erreur, la page affichée est DownloadIndex.
            Assert.IsTrue(ConfirmationUploadCVLetterPage.IsDisplayed); 
        }

    }
}
