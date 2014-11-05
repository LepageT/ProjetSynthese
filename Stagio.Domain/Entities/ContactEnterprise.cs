using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    public class ContactEnterprise : ApplicationUser
    {
        [Required(ErrorMessage = "Requis")]
        public string EnterpriseName { get; set; }

        public string Poste { get; set; }
        
    }
}
