using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Stagio.Domain.Entities
{
    public class Student : ApplicationUser
    {
        [Required]

        public int Matricule { get; set; }


        [DefaultValue(false)]
        public bool Activated { get; set; }

        public string Email { get; set; }

    }
}
