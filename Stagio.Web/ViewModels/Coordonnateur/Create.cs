using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Stagio.DataLayer;

namespace Stagio.Web.ViewModels.Coordonnateur
{
    public class Create
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Requis")]
        [MinLength(8, ErrorMessage = "Le mot de passe est trop cours. Il doit contenir au moins 8 caractères.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Les mot de passes ne correspondent pas")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}