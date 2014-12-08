using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class RemoveStudent
    {
        public int Id { get; set; }

        public int Matricule { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Retirer?")]
        [DefaultValue(false)]
        public bool Remove { get; set; }

        
    }
}