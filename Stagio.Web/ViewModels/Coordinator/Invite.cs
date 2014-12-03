using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class Invite
    {
        [DisplayName("Courriel")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [DisplayName("Message")]
        public String Message { get; set; }
    }
}