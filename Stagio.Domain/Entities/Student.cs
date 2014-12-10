using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Domain.Entities
{
    public class Student : ApplicationUser
    {
        [Required]

        public int Matricule { get; set; }

        public bool hadStage { get; set; }
    }
}
