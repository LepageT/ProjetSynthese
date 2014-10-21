using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class Stage : Entity
    {
        public DateTime publicationDate { get; set; }

        //Maybe an enterprise entity must be created.
        public String companyName { get; set; }

        public String adresse { get; set; }


        //Responsable
        public String responsableToName { get; set; }

        public String responsableToTitle { get; set; }

        public String responsableToEmail { get; set; }

        public String responsableToPhone { get; set; }

        public int? responsableToPoste { get; set; }

        //Contact

        public String contactToName { get; set; }

        public String contactToTitle { get; set; }

        public String contactToEmail { get; set; }

        public String contactToPhone { get; set; }

        public int? contactToPoste { get; set; }


        public String stageDescription { get; set; }

        public String environnementDescription { get; set; }

        public int nbrStagiaire { get; set; }

        //Submit to:
        public String submitToName { get; set; }

        public String submitToTitle { get; set; }

        public String submitToEmail { get; set; }

    }
}
