using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    public class ApplicationUser : Entity
    {
        //[Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        public string Password { get; set; }
       // [Required]
        public string UserName { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
        
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        public string Telephone { get; set; }

        public string Poste { get; set; }

        public string Email { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
        public bool Active { get; set; }
        public ApplicationUser()
        {
            Roles = new List<UserRole>();
        }
    }
}
