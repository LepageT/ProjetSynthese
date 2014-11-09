using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Student
{
    public class AppliedStages
    {
        [DisplayName("Titre du stage")]
        [Required(ErrorMessage = "Requis")]
        public String stageTitle { get; set; }

        [DisplayName("Nom de l'entreprise")]
        [Required(ErrorMessage = "Requis")]
        public String CompanyName { get; set; }

        [DisplayName("Descritpion du stage")]
        [Required(ErrorMessage = "Requis")]
        public String StageDescription { get; set; }

        [DisplayName("Status du stage")]
        [Required(ErrorMessage = "Requis")]
        //Maybe an enterprise entity must be created.
        public int Status { get; set; }

        public int IdStage { get; set; }

        public int Id { get; set; }

        [DefaultValue(0)]
        public int StudentReply { get; set; }

    }
}