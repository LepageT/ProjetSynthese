using System.Collections.Generic;

namespace Stagio.Web.ViewModels.StageAgreement
{
    public class ListStageAgreement
    {
        public List<StageAgreementDetail> ListStageAgreementNotSigned { get; set; }
        public List<StageAgreementDetail> ListStagesAgreementsSigned { get; set; }
    }
}