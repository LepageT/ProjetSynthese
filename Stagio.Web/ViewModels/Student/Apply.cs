using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Student
{
    public class Apply
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

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