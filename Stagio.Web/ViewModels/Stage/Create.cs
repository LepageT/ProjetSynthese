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
        public String companyName { get; set; }

        [DisplayName("Adresse")]
        [Required(ErrorMessage = "Requis")]
        public String adresse { get; set; }

        //Responsable 
        [DisplayName("Nom")]
        [Required(ErrorMessage = "Requis")]
        public String responsableToName { get; set; }

        [DisplayName("Titre")]
        [Required(ErrorMessage = "Requis")]
        public String responsableToTitle { get; set; }

        [DisplayName("Courriel")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Requis")]
        public String responsableToEmail { get; set; }

        [DisplayName("Téléphone")]
        [Required(ErrorMessage = "Requis")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        public String responsableToPhone { get; set; }

        [DisplayName("Poste")]
        public int? responsableToPoste { get; set; }

        //Contact

        [DisplayName("Nom")]
        public String contactToName { get; set; }

        [DisplayName("Titre")]
        public String contactToTitle { get; set; }

        [DisplayName("Courriel")]
        [DataType(DataType.EmailAddress)]
        public String contactToEmail { get; set; }

        [DisplayName("Téléphone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        public String contactToPhone { get; set; }

        [DisplayName("Poste")]
        public int? contactToPoste { get; set; }

        [DisplayName("Titre du poste")]
        [Required(ErrorMessage = "Requis")]
        public String stageTitle { get; set; }

        [DisplayName("Description du projet")]
        [Required(ErrorMessage = "Requis")]
        public String stageDescription { get; set; }

        [DisplayName("Environnement matériel et logiciel spécifique au projet")]
        [Required(ErrorMessage = "Requis")]
        public String environnementDescription { get; set; }

        [DisplayName("Nombre de stagiaires")]
        [Required(ErrorMessage = "Requis")]
        public int nbrStagiaire { get; set; }

        //Submit to:
        [DisplayName("Nom")]
        [Required(ErrorMessage = "Requis")]
        public String submitToName { get; set; }

        [DisplayName("Titre")]
        [Required(ErrorMessage = "Requis")]
        public String submitToTitle { get; set; }

        [DisplayName("Courriel")]
        [Required(ErrorMessage = "Requis")]
        [DataType(DataType.EmailAddress)]
        public String submitToEmail { get; set; }

        [DisplayName("Date limite pour soumettre une candidature")]
        [Required(ErrorMessage = "Requis")]
        public DateTime limitDate { get; set; }

    }
}