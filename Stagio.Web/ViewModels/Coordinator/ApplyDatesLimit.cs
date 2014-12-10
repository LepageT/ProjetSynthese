using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class ApplyDatesLimit
    { 
        [DisplayName("Date de début de la période de candidature pour les stages")]
        [Required(ErrorMessage = "Veuillez spécifier une date de début des stages.")]
        public String DateBegin { get; set; }

        [DisplayName("Date de fin de la période de candidature pour les stages")]
        [Required(ErrorMessage = "Veuillez spécifier une date de fin des stages.")]
        public String DateEnd { get; set; }
    }
}