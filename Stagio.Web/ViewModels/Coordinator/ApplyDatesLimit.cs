using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class ApplyDatesLimit
    { 
        [DisplayName("Date de début de la période de postulation pour les stages")]
        [Required(ErrorMessage = "Veuillez spécifier une date de début des stages.")]
        public String DateBegin { get; set; }

        [DisplayName("Date de fin de la période de postulation pour les stages")]
        [Required(ErrorMessage = "Veuillez spécifier une date de fin des stages.")]
        public String DateEnd { get; set; }
    }
}