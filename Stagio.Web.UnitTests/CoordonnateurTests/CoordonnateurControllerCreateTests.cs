using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using AutoMapper;
using FluentAssertions;

namespace Stagio.Web.UnitTests.CoordonnateurTests
{
    [TestClass]
    public class CoordonnateurControllerCreateTests : CoordonnateurControllerBaseClassTests
    {
        [TestMethod]
        public void coordonnateur_create_get_should_return_view_with_createCoordonnateur_viewModels_when_invitation_is_valid()
        {
            var invitation = _fixture.Create<Invitation>();
            invitation.Used = false;
            invitationRepository.GetAll().FirstOrDefault().Returns(invitation);
            var viewModelExpected = Mapper.Map<ViewModels.Coordonnateur.Create>(invitation);

            var viewResult = coordonnateurController.Create(invitation.Token) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Coordonnateur.Create;

            //Assert 
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 

        }

        [TestMethod]
        public void coordonnateur_create_get_should_return_httpnotfound_when_invitation_is_null()
        {

        }

        [TestMethod]
        public void coordonnateur_create_get_should_return_httpnotfound_when_invitation_is_already_used()
        {

        }

        [TestMethod]
        public void coordonnateur_create_get_should_return_create_view_when_invitation_is_unsued()
        {

        }

        [TestMethod]
        public void coordonnateur_create_get_should_return_default_view_when_modelState_is_not_valid()
        {

        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_default_view_when_email_is_already_used()
        {

        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_httpnotfound_if_invitation_is_not_found()
        {

        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_httpnotfound_if_invitation_email_is_different_of_the_email_entered()
        {

        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_index_on_success()
        {

        }
    }
}
