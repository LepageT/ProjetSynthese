using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class StudentList
    {
        public int Id { get; set; }

        public int Matricule { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Nombre de candidatures")]
        public int NbApply { get; set; }

        [DisplayName("Nombre d'entrevues")]
        public int NbDateInterview { get; set; }

        [DisplayName("Stage accepter le")]
        public string DateAccepted { get; set; }
        
    }
}