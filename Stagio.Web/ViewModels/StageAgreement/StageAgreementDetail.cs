using System.ComponentModel;

namespace Stagio.Web.ViewModels.StageAgreement
{
    public class StageAgreementDetail
    {
        [DisplayName("Prénom de l'étudiant")]
        public string StudentFirstName { get; set; }

        [DisplayName("Nom de l'étudiant")]
        public string StudentLastName { get; set; }

        [DisplayName("Nom de l'entreprise")]
        public string EnterpriseName { get; set; }

        [DisplayName("Stage")]
        public string StageName { get; set; }

    }
}