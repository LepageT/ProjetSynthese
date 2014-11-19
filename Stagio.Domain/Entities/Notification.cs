using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class Notification : Entity
    {

        public String Title { get; set; }

        public String Message { get; set; }

        public int For { get; set; }

        public Boolean Seen { get; set; }

        public DateTime Date { get; set; }
    }
}
