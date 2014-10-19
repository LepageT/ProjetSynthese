using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Student
{
    public class ListStudent
    {
        [DisplayName("Matricule")]
        public int Matricule { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }
    }
}