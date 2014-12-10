using System;
using System.ComponentModel;

namespace Stagio.Web.ViewModels.Stage
{
    public class Details
    {
        public int Id { get; set; }

        [DisplayName("Date de l'offre")]
        public string PublicationDate { get; set; }

        //Maybe an enterprise entity must be created.
        [DisplayName("Entreprise ou Organisation")]
        public String CompanyName { get; set; }
        [DisplayName("Adresse")]
        public String Adresse { get; set; }


        //Responsable
        [DisplayName("Nom:")]
        public String ResponsableToName { get; set; }
        [DisplayName("Titre:")]
        public String ResponsableToTitle { get; set; }
        [DisplayName("Courriel:")]
        public String ResponsableToEmail { get; set; }
        [DisplayName("Téléphone:")]
        public String ResponsableToPhone { get; set; }
        [DisplayName("Poste:")]
        public string ResponsableToPoste { get; set; }

        //Contact
        [DisplayName("Nom:")]
        public String ContactToName { get; set; }
        [DisplayName("Titre:")]
        public String ContactToTitle { get; set; }
        [DisplayName("Courriel:")]
        public String ContactToEmail { get; set; }
        [DisplayName("Téléphone:")]
        public String ContactToPhone { get; set; }
        [DisplayName("Poste:")]
        public string ContactToPoste { get; set; }

        [DisplayName("Description du projet pour le stage")]
        public String StageDescription { get; set; }
        [DisplayName("Environnement matériel et logiciel spécifique au projet")]
        public String EnvironnementDescription { get; set; }
        [DisplayName("Nombre de stagiaires")]
        public int NbrStagiaire { get; set; }

        [DisplayName("Stagiaire si connu:")]
        public string StagiaireIfKnew { get; set; }
        [DisplayName("Nom:")]
        //Submit to:
        public String SubmitToName { get; set; }
        [DisplayName("Titre:")]
        public String SubmitToTitle { get; set; }
        [DisplayName("Courriel:")]
        public String SubmitToEmail { get; set; }
        [DisplayName("Date limite pour soummettre une candidature")]
        public String LimitDate { get; set; }

        public int Status { get; set; }
    }
}