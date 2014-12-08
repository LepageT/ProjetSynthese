using System.ComponentModel;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class StudentApplyList
    {
        public int Id { get; set; }

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
        public string DateApply { get; set; }

        [DisplayName("Date de l'entrevue")]
        public string DateInterview { get; set; }

        [DisplayName("Date de l'offre reçu")]
        public string DateStageOffer { get; set; }

        [DisplayName("Date d'acceptation de l'offre")]
        public string DateAcceptStage { get; set; }

        [DefaultValue(false)]
        public bool StageAgreementCreated { get; set; }
    }
}