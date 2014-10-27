using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Student
{
    public class Apply
    {
        [DisplayName("CV")]
        [Required(ErrorMessage = "Requis")]
        public string Cv { get; set; }

        [DisplayName("Lettre de présentation")]
        [Required(ErrorMessage = "Requis")]
        public string Letter { get; set; }

        [Required(ErrorMessage = "Requis")]
        public int IdStudent { get; set; }

        [Required(ErrorMessage = "Requis")]
        public int IdStage { get; set; }
    }
}