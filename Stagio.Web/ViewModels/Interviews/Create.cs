﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stagio.Web.ViewModels.Interviews
{
    public class Create
    {
        [DisplayName("Date de l'entrevue")]
        [Required(ErrorMessage = "Veuillez spécifier une date d'entrevue.")]
        public String Date { get; set; }

        [DisplayName("Stage")]
        [Required(ErrorMessage = "Veuillez sélectionner le stage auquel vous avez une entrevue.")]
        public int StageId { get; set; }

        public int StudentId { get; set; }

        public IEnumerable<SelectListItem> Apply { get; set; } 

    }
}