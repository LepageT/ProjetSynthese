using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.DataLayer.EntityFramework;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;
using Stagio.Web.Validations;

namespace Stagio.Web.UnitTests.ValidationTests
{
    [TestClass]
    public class ValidationVerifyIfEmailIsUniqueTest : ValidationVerifyIfEmailIsUnique
    {


        [TestMethod]
        public void email_should_be_valid_if_it_is_not_in_db()
        {
            const string emailValid = "testEmail@hotmail.com";
            IEntityRepository<ContactEnterprise> contactEnterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();

            var resultValidEmail = IsValid(emailValid);

            resultValidEmail.ShouldBeEquivalentTo(true);
        }


        [TestMethod]
        public void email_should_be_invalid_if_it_is_in_db()
        {
            ContactEnterprise contactEnterpriseTest = new ContactEnterprise()
            {
                Id = 1,
                EnterpriseName = "tekhjst",
                FirstName = "Qukjhentin",
                LastName = "Tarakjhntino",
                Telephone = "123-456-7890",
                Email = "blakjhbla@hotmail.com",
                Password = PasswordHash.CreateHash("qwejrty12"),
                Active = false
            };
            contactEnterpriseTest.UserName = contactEnterpriseTest.Email;
            IEntityRepository<ContactEnterprise> contactEnterpriseRepository = new EfEntityRepository<ContactEnterprise>();
            contactEnterpriseRepository.Add(contactEnterpriseTest);

            var resultValidEmail = IsValid(contactEnterpriseTest.Email);

            resultValidEmail.ShouldBeEquivalentTo(false);

        }

    }
}
