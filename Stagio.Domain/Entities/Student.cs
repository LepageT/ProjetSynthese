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
        public int Matricule { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        [Required(ErrorMessage = "Requis")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        public string Password { get; set; }


    }
}
