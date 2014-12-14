using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class Misc : Entity
    {
        //Site open to public dates
        public string StartApplyDate { get; set; }
        public string EndApplyDate { get; set; }

        //SMTP options
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}
