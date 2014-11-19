using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class StudentApplyList
    {
        public int IdStudent { get; set; }

        public int Matricule { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Entreprise")]
        public string EnterpriseName { get; set; }

        public int IdStage { get; set; }

        [DisplayName("Titre du stage")]
        public string StageTitle { get; set; }

        [DisplayName("Date de la candidature")]
        public DateTime DateApply { get; set; }

        [DisplayName("Date de l'entrevue")]
        public DateTime DateInterview { get; set; }

        [DisplayName("Date de l'offre reçu")]
        public DateTime DateStageOffer { get; set; }

        [DisplayName("Date d'acceptation de l'offre")]
        public DateTime DateAcceptStage { get; set; }
    }
}