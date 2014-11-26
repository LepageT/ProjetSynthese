using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class StageAgreement : Entity
    {
        public DateTime DateStageStart { get; set; }

        public DateTime DateStageEnd { get; set; }

        public int IdStage { get; set; }

        public bool CoordinatorHasSigned { get; set; }

        public int IdCoordinatorSigned { get; set; }

        public DateTime DateCoordinatorSigned { get; set; }

        public bool StudentHasSigned { get; set; }

        public int IdStudentSigned { get; set; }

        public DateTime DateStudentSigned { get; set; }

        public bool ContactEnterpriseHasSigned { get; set; }

        public int IdContactEnterpriseSigned { get; set; }

        public DateTime DateContactEnterpriseSigned { get; set; }
    }
}
