using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Stagio.Domain.Entities;

namespace Stagio.Web.ViewModels.Stage
{
    public class ListNewStages
    {

        public int Id { get; set; }
         [DisplayName("Date de l'offre")]
        public String PublicationDate { get; set; }

        [DisplayName("Entreprise ou Organisation")]
        [Required(ErrorMessage = "Requis")]
        
        public String CompanyName { get; set; }

        [DisplayName("Titre du stage")]
        [Required(ErrorMessage = "Requis")]
        public String StageTitle { get; set; }

        [DisplayName("Date de fin de soumission")]
        [Required(ErrorMessage = "Requis")]
        public String LimitDate { get; set; }

        [DisplayName("Nombre de stagiaire(s) désiré(s)")]
        [Required(ErrorMessage = "Requis")]
        public int NbrStagiaire { get; set; }
         [DisplayName("Nombre de candidature(s)")]
        public int NbApply { get; set; }
         [DisplayName("Nombre de stagiaire(s) trouvé(s)")]
        public int NbrStagiaireFind { get; set; }


         [DefaultValue(StageStatus.New)]
         public StageStatus Status { get; set; }

      
    
       
    }
}