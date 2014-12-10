using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.Student
{
    public class ListStudent
    {
        public int Id  { get; set; }

        [DisplayName("Matricule")]
        [Range(1000000, 9999999)]
        public int Matricule { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }
    }
}