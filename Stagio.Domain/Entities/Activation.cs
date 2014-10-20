using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class Activation : Entity
    {
        public int AccountType { get; set; }

        public int AccountId { get; set; }

        public string Token { get; set; }
    }
}
