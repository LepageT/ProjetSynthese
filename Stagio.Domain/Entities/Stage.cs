using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class Stage : Entity
    {
        [DisplayName("Date de publication")]
        public DateTime PublicationDate { get; set; }

        //Maybe an enterprise entity must be created.
        public String CompanyName { get; set; }

        public String Adresse { get; set; }


        //Responsable
        public String ResponsableToName { get; set; }

        public String ResponsableToTitle { get; set; }

        public String ResponsableToEmail { get; set; }

        public String ResponsableToPhone { get; set; }

        public int? ResponsableToPoste { get; set; }

        //Contact

        public String ContactToName { get; set; }

        public String ContactToTitle { get; set; }

        public String ContactToEmail { get; set; }

        public String ContactToPhone { get; set; }

        public int? ContactToPoste { get; set; }


        public String StageDescription { get; set; }

        public String EnvironnementDescription { get; set; }

        public int NbrStagiaire { get; set; }

        //Submit to:
        public String SubmitToName { get; set; }

        public String SubmitToTitle { get; set; }

        public String SubmitToEmail { get; set; }

        public DateTime LimitDate { get; set; }

        public Boolean AcceptedByCoordinator { get; set; }

    }
}
