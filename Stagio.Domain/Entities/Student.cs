using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    public class Student : ApplicationUser
    {
        [Required]

        public int Matricule { get; set; }

        public string Poste { get; set; }

        [DefaultValue(false)]
        public bool Activated { get; set; }


    }
}
