using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class ContactEnterprise : ApplicationUser
    {
        [Required(ErrorMessage = "Requis")]
        public string EnterpriseName { get; set; }

        public int? Poste { get; set; }
       
    }
}
