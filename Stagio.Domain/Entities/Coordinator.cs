using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Stagio.Domain.Entities
{
    public class Coordinator : Entity
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Requis")]
        [MinLength(8)]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
