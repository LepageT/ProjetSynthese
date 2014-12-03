using System.ComponentModel;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class StudentList
    {
        public int Id { get; set; }

        public int Matricule { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Nombre de candidatures")]
        public int NbApply { get; set; }

        [DisplayName("Nombre d'entrevues")]
        public int NbDateInterview { get; set; }
        
    }
}