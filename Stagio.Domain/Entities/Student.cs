using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    class Student : Entity
    {
        public int Id { get; set; }

        public string Matricule { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        [Required]
        [StringLength(10)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(8)]
        public string Password { get; set; }
    }
}
