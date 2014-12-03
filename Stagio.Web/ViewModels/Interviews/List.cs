using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.Interviews
{
    public class List
    {
        [DisplayName("Date de l'entrevue")]
        [Required(ErrorMessage = "Veuillez spécifier une date d'entrevue.")]
        public String Date { get; set; }

        [DisplayName("Stage")]
        [Required(ErrorMessage = "Veuillez sélectionner le stage auquel vous avez une entrevue.")]
        public int StageId { get; set; }

          [DisplayName("Stage")]
        public string StageTitleAndCompagny { get; set; }

        [DisplayName("Je me suis présenté à l'entrevue")]
        public bool Present { get; set; }

        public int Id { get; set; }
    }
}