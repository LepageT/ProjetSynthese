﻿using Stagio.Web.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class InviteContactEnterprise
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Courriel")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Confirmation Courriel")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Email", ErrorMessage = "Les emails ne correspondent pas")]
        public string ConfirmEmail { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Requis")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Requis")]
        public string FirstName { get; set; }

        [DisplayName("Nom de l'entreprise")]
        [Required(ErrorMessage = "Requis")]
        public string EnterpriseName { get; set; }

        [DisplayName("Téléphone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        [Required(ErrorMessage = "Requis")]
        public string Telephone { get; set; }

        [DisplayName("Poste")]
        public string Poste { get; set; }

        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [ValidationPassword]
        public string Password { get; set; }

        [DisplayName("Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage = "Les mot de passes ne correspondent pas")]
        public string PasswordConfirmation { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool Active { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Message")]
        public String Message { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Token { get; set; }

        public int InvitationId { get; set; }
    }
}