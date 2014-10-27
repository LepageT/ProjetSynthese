using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class Stage : Entity
    {
        [DisplayName("Date de l'offre")]
        public DateTime PublicationDate { get; set; }

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
        public int? ResponsableToPoste { get; set; }

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
        public int? ContactToPoste { get; set; }

        [DisplayName("Description du projet pour le stage")]
        public String StageDescription { get; set; }
        [DisplayName("Environnement matériel et logiciel spécifique au projet")]
        //Stage information
        public string StageTitle { get; set; }

        public String EnvironnementDescription { get; set; }
        [DisplayName("Nombre de stagiaires")]
        public int NbrStagiaire { get; set; }
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
        public DateTime LimitDate { get; set; }

        //0 => Nouveau
        //1 => Accepter
        //2 => Refuser
        [DefaultValue(0)]
        [Range(0,3)]
        public int Status  { get; set; }
    }
}
