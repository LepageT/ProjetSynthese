using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Validations;

namespace Stagio.Web.UnitTests.ValidationTests
{
    [TestClass]
    public class ValidationPasswordTests : ValidationPassword
    {
        [TestMethod]
        public void validation_password_with_2_letters_2_numbers_and_8_characters_should_be_valid()
        {
            const string VALID_PASSWORD = "1qwerty2";

            var resultValidityPassword = IsValid(VALID_PASSWORD);

            resultValidityPassword.ShouldBeEquivalentTo(true);
        }

        [TestMethod]
        public void validation_password_with_no_letter_should_not_be_valid()
        {
            const string VALID_PASSWORD = "123456789";

            var resultValidityPassword = IsValid(VALID_PASSWORD);

            resultValidityPassword.ShouldBeEquivalentTo(false);
        }


        [TestMethod]
        public void validation_password_with_no_numbers_should_not_be_valid()
        {
            const string VALID_PASSWORD = "aqwertyb";

            var resultValidityPassword = IsValid(VALID_PASSWORD);

            resultValidityPassword.ShouldBeEquivalentTo(false);
        }

        [TestMethod]
        public void validation_password_with_less_than_8_characters_should_not_be_valid()
        {
            const string VALID_PASSWORD = "mot";

            var resultValidityPassword = IsValid(VALID_PASSWORD);

            resultValidityPassword.ShouldBeEquivalentTo(false);
        }

        [TestMethod]
        public void validation_password_with_2_letters_2_numbers_and_more_than_8_characters_should_be_valid()
        {
            const string VALID_PASSWORD = "1qwerty2blabla";

            var resultValidityPassword = IsValid(VALID_PASSWORD);

            resultValidityPassword.ShouldBeEquivalentTo(true);
        }
    }
}
