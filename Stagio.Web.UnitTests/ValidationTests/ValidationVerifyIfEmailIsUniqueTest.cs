using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
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

            var resultValidEmail = IsValid(emailValid);

            resultValidEmail.ShouldBeEquivalentTo(true);
        }

        [TestMethod]
        public void email_should_be_invalid_if_it_is_in_db()
        {
          /*ContactEnterprise contactEnterpriseTest = new ContactEnterprise()
            {
                Email = "testEmail@hotmail.com"
            };
            List<ContactEnterprise> listEnterprises = new List<ContactEnterprise>();
            listEnterprises.Add(contactEnterpriseTest);
            IEntityRepository<ContactEnterprise> contactEnterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            contactEnterpriseRepository.Add(contactEnterpriseTest);
            contactEnterpriseRepository.GetAll().Returns(listEnterprises.AsQueryable());
         

            const string emailInvalid = "testEmail@hotmail.com";

            var resultValidEmail = IsValid(emailInvalid);

            resultValidEmail.ShouldBeEquivalentTo(false);*/
        }

    }
}
