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
        public string LastName { get; set; }

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Le mot de passe n'est pas identique.")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        public string Email { get; set; }
    }
}