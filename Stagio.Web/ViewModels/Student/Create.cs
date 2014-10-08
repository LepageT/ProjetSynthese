using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Student
{
    public class Create
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Matricule { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Password { get; set; }

    }
}