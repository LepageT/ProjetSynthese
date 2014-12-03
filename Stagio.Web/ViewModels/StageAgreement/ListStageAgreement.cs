using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.StageAgreement
{
    public class ListStageAgreement
    {
        public List<StageAgreementDetail> ListStageAgreementNotSigned { get; set; }
        public List<StageAgreementDetail> ListStagesAgreementsSigned { get; set; }
    }
}