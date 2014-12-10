using System;
using System.ComponentModel.DataAnnotations;

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

        public StatusApply Status { get; set; }

        public DateTime DateApply { get; set; }

    }
        
    [Flags]
    public enum StatusApply
    {
        Waitting = 0,
        Accepted = 1,
        Refused = 2,
        Removed = 3
    }

}
