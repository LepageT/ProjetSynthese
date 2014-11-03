using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Stagio.DataLayer;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class Create
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Requis")]
        [MinLength(8, ErrorMessage = "Le mot de passe est trop cours. Il doit contenir au moins 8 caractères.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirmation")]
        [Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Les mot de passes ne correspondent pas")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        [DisplayName("Courriel")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Confirmation Courriel")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Email", ErrorMessage = "Les emails ne correspondent pas")]
        public string ConfirmEmail { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Token { get; set; }

        public int InvitationId { get; set; }
    }
 
}