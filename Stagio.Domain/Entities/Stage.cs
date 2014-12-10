using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    public class Stage : Entity
    {
        [DisplayName("Date de l'offre")]
        public string PublicationDate { get; set; }

        //Maybe an enterprise entity must be created.
        [DisplayName("Entreprise ou Organisation")]
        public String CompanyName { get; set; }

        public String Adresse { get; set; }

        //Responsable
        [DisplayName("Nom")]
        public String ResponsableToName { get; set; }
        [DisplayName("Titre")]
        public String ResponsableToTitle { get; set; }
        [DisplayName("Courriel")]
        public String ResponsableToEmail { get; set; }
        [DisplayName("Téléphone")]
        public String ResponsableToPhone { get; set; }
        [DisplayName("Poste")]
        public string ResponsableToPoste { get; set; }

        //Contact
        [DisplayName("Nom")]
        public String ContactToName { get; set; }
        [DisplayName("Titre")]
        public String ContactToTitle { get; set; }
        [DisplayName("Courriel")]
        public String ContactToEmail { get; set; }
        [DisplayName("Téléphone")]
        public String ContactToPhone { get; set; }
        [DisplayName("Poste")]
        public string ContactToPoste { get; set; }

        [DisplayName("Description du projet pour le stage")]
        public String StageDescription { get; set; }
        //Stage information
        [DisplayName("Environnement matériel et logiciel spécifique au projet")]
        public String EnvironnementDescription { get; set; }
        public string StageTitle { get; set; }
        [DisplayName("Nombre de stagiaires")]
        public int? NbrStagiaire { get; set; }
        [DisplayName("Stagiaire si connu:")]
        public string StagiaireIfKnew { get; set; }
        [DisplayName("Nom")]

        //Submit to:
        public String SubmitToName { get; set; }
        [DisplayName("Titre")]
        public String SubmitToTitle { get; set; }
        [DisplayName("Courriel")]
        public String SubmitToEmail { get; set; }
        [DisplayName("Date limite pour soummettre une candidature")]
        public string LimitDate { get; set; }

        [DefaultValue(StageStatus.New)]
        public StageStatus Status { get; set; }

        [DefaultValue(0)]
        public int NbApply { get; set; }

    }


    [Flags]
    public enum StageStatus
    {
        New = 0,
        Accepted = 1,
        Refused = 2,
        Removed = 3,
        Draft = 4
    }
}
