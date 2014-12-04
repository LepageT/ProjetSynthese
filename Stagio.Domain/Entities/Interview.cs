using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class Interview : Entity
    {
        public String Date { get; set; }

        public int StageId { get; set; }

        [DefaultValue(false)]
        public bool Present { get; set; }

        public int StudentId { get; set; }

        public String DateOffer { get; set; }

        public String DateAcceptOffer { get; set; }

    }
}
