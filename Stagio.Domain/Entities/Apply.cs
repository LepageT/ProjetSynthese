using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagio.Domain.Entities
{
    public class Apply : Entity
    {
        [Required(ErrorMessage = "Requis")]
        public string Cv { get; set; }

        [Required(ErrorMessage = "Requis")]
        public string Letter { get; set; }

        public int IdStudent { get; set; }

        public int IdStage { get; set; }

    }
}
