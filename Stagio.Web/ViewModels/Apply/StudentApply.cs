using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Apply
{
    public class StudentApply
    {
        [DisplayName("Matricule")]
        [Range(1000000, 9999999)]
        public int Matricule { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        public int Id { get; set; }
         [DisplayName("CV")]
        [Required(ErrorMessage = "Requis")]
        public string Cv { get; set; }
        [DisplayName("Lettre de présentation")]
        [Required(ErrorMessage = "Requis")]
        public string Letter { get; set; }

        public int IdStudent { get; set; }

        public int IdStage { get; set; }
        public string StageTitle { get; set; }

        public int Status { get; set; }
    }
}