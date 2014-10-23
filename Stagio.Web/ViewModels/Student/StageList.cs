using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Stagio.Web.ViewModels.Student
{
    public class StageList
    {
        [DisplayName("Numéro du stage")]
        [Required(ErrorMessage = "Requis")]
        public String Id{ get; set; }        
        
        [DisplayName("Nom de l'entreprise")]
        [Required(ErrorMessage = "Requis")]
        //Maybe an enterprise entity must be created.
        public String companyName { get; set; }

        [DisplayName("Titre du poste")]
        [Required(ErrorMessage = "Requis")]
        public String stageTitle { get; set; }

        [DisplayName("Date limite pour soumettre une candidature")]
        [Required(ErrorMessage = "Requis")]
        public DateTime limitDate { get; set; }
    }
}