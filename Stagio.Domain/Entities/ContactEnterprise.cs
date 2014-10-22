using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class ContactEnterprise : Entity
    {
        [Required(ErrorMessage = "Requis")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Requis")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Requis")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Requis")]
        public string EnterpriseName { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        [Required(ErrorMessage = "Requis")]
        public string Telephone { get; set; }

        public int? Poste { get; set; }

        [Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        public string Password { get; set; }

        public bool Active { get; set; }
    }
}
