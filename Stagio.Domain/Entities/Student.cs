using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    public class Student : Entity
    {
        [Range(1000000, 1999999)]
        public int Matricule { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MaxLength(12)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(8)]
        public string Password { get; set; }
    }
}
