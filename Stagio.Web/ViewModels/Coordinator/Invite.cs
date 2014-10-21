using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Stagio.DataLayer;

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