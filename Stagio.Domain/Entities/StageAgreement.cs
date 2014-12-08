using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class StageAgreement : Entity
    {
        public string DateStageStart { get; set; }

        public string DateStageEnd { get; set; }

        public int IdStage { get; set; }

        [DefaultValue(false)]
        public bool CoordinatorHasSigned { get; set; }

        public int IdCoordinatorSigned { get; set; }
        [DisplayName("Date")]
        public string DateCoordinatorSigned { get; set; }

        [DefaultValue(false)]
        public bool StudentHasSigned { get; set; }

        public int IdStudentSigned { get; set; }

        public string DateStudentSigned { get; set; }

        [DefaultValue(false)]
        public bool ContactEnterpriseHasSigned { get; set; }

        public int IdContactEnterpriseSigned { get; set; }

        public string DateContactEnterpriseSigned { get; set; }

        public bool Renumeration { get; set; }
        [DisplayName("Nom du professeur superviseur du stage de l'étudiant")]
        public string SupervisorName { get; set; }

    }
}
