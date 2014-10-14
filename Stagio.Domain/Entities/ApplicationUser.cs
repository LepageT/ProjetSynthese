using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class ApplicationUser : Entity
    {
        [Required]
        //[Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entrez un numéro valide.")]
        [Required(ErrorMessage = "Requis")]
        public string Telephone { get; set; }
        /*Si nombre X maximum de connexions echoues, ajouter un fail counter + timestamp de quand le counter est rendu a 4
         */ 
        
        //Navigation properties
        public virtual ICollection<UserRole> Roles { get; set; }

        public ApplicationUser()
        {
            Roles = new List<UserRole>();
        }
    }
}
