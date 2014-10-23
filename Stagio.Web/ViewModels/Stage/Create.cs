using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Stage
{
    public class Create
    {
        [DisplayName("Entreprise ou Organisation")]
        [Required(ErrorMessage = "Requis")]
        //Maybe an enterprise entity must be created.
        public String CompanyName { get; set; }

        [DisplayName("Adresse")]
        [Required(ErrorMessage = "Requis")]
        public String Adresse { get; set; }

        //Responsable 
        [DisplayName("Nom")]
        [Required(ErrorMessage = "Requis")]
        public String ResponsableToName { get; set; }

        [DisplayName("Titre")]
        [Required(ErrorMessage = "Requis")]
        public String ResponsableToTitle { get; set; }

        [DisplayName("Courriel")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Requis")]
        public String ResponsableToEmail { get; set; }

        [DisplayName("Téléphone")]
        [Required(ErrorMessage = "Requis")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        public String ResponsableToPhone { get; set; }

        [DisplayName("Poste")]
        public int? ResponsableToPoste { get; set; }

        //Contact

        [DisplayName("Nom")]
        public String ContactToName { get; set; }

        [DisplayName("Titre")]
        public String ContactToTitle { get; set; }

        [DisplayName("Courriel")]
        [DataType(DataType.EmailAddress)]
        public String ContactToEmail { get; set; }

        [DisplayName("Téléphone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        public String ContactToPhone { get; set; }

        [DisplayName("Poste")]
        public int? ContactToPoste { get; set; }


        [DisplayName("Description du projet")]
        [Required(ErrorMessage = "Requis")]
        public String StageDescription { get; set; }

        [DisplayName("Environnement matériel et logiciel spécifique au projet")]
        [Required(ErrorMessage = "Requis")]
        public String EnvironnementDescription { get; set; }

        [DisplayName("Nombre de stagiaires")]
        [Required(ErrorMessage = "Requis")]
        public int NbrStagiaire { get; set; }

        //Submit to:
        [DisplayName("Nom")]
        [Required(ErrorMessage = "Requis")]
        public String SubmitToName { get; set; }

        [DisplayName("Titre")]
        [Required(ErrorMessage = "Requis")]
        public String SubmitToTitle { get; set; }

        [DisplayName("Courriel")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.EmailAddress)]
        public String SubmitToEmail { get; set; }

        [DisplayName("Date limite pour soumettre une candidature")]
        [Required(ErrorMessage = "Requis")]
        public DateTime LimitDate { get; set; }

    }
}