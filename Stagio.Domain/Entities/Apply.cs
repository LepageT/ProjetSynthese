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

        public Status Status { get; set; }

        public Status StudentReply { get; set; }

    }

    public enum Status
    {
        Waitting = 0,
        Accepted = 1,
        Refused = 2,
        Removed = 3
    }

}
