using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.StageAgreement
{
    public class EditStageAgreement
    {
        public int Id { get; set; }

        [DisplayName("Date de début de stage")]
        public string DateStageStart { get; set; }
         [DisplayName("Date de fin de stage")]
        public string DateStageEnd { get; set; }

        public int IdStage { get; set; }


        public bool CoordinatorHasSigned { get; set; }

        public int IdCoordinatorSigned { get; set; }
        [DisplayName("Date")]
        public string DateCoordinatorSigned { get; set; }

      
        public bool StudentHasSigned { get; set; }

        public int IdStudentSigned { get; set; }

        [DisplayName("Date")]
        public string DateStudentSigned { get; set; }

      
        public bool ContactEnterpriseHasSigned { get; set; }

        public int IdContactEnterpriseSigned { get; set; }
        [DisplayName("Date")]
        public string DateContactEnterpriseSigned { get; set; }

         [DisplayName("Nom de l'entreprise")]
        public string CompanyName { get; set; }

        public string Adresse { get; set; }
         [DisplayName("Le stage est rémunéré")]
        public bool Renumeration { get; set; }
        [DisplayName("Responsable")]
        public String ResponsableToName { get; set; }
        [DisplayName("Titre")]
        public String ResponsableToTitle { get; set; }
        [DisplayName("Courriel")]
        public String ResponsableToEmail { get; set; }
        [DisplayName("Téléphone")]
        public String ResponsableToPhone { get; set; }
        [DisplayName("Poste")]
        public string ResponsableToPoste { get; set; }

        public int Matricule { get; set; }
        [DisplayName("Nom du stagiaire")]
        public string StudentName { get; set; }
        [DisplayName("Coordonnateur des stages")]
        public string CoordinatorName { get; set; }
        [DisplayName("Téléphone")]
        public string CoordinatorPhone { get; set; }
        [DisplayName("Poste")]
        public string CoordinatorPoste { get; set; }
        [DisplayName("Courriel")]
        public string CoordinatorEmail { get; set; }
        [DisplayName("Signature du responsable")]
        [DataType(DataType.Password)] 
        public string ContactEnterpriseSignature { get; set; }
         [DisplayName("Signature du stagiaire")]
         [DataType(DataType.Password)] 
        public string StudentSignature { get; set; }
         [DataType(DataType.Password)] 
         [DisplayName("Signature du coordonnateur")]
        public string CoordinatorSignature { get; set; }

         [DisplayName("Nom du professeur superviseur du stage de l'étudiant")]
         public string SupervisorName { get; set; }

    }
}