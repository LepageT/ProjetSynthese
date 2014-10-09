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

        //Navigation properties
        public virtual ICollection<UserRole> Roles { get; set; }

        public ApplicationUser()
        {
            Roles = new List<UserRole>();
        }
    }
}
